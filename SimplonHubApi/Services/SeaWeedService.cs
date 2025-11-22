using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using SimplonHubApi.Utilities;

namespace SimplonHubApi.Services
{
    public class SeaweedStorageService
    {
        private readonly IAmazonS3 _s3;
        private readonly string _bucket;
        private readonly string _publicUrl;
        private readonly ILogger<SeaweedStorageService> _logger;

        public SeaweedStorageService(IConfiguration config, ILogger<SeaweedStorageService> logger)
        {
            _logger = logger;
            _bucket = EnvironmentVariables.S3_BUCKET;
            _publicUrl = EnvironmentVariables.S3_SERVICE_URL;

            _logger.LogInformation(
                $"Initializing SeaweedFS with URL: {EnvironmentVariables.S3_SERVICE_URL}"
            );
            _logger.LogInformation($"Bucket: {_bucket}");

            var credentials = new BasicAWSCredentials(
                EnvironmentVariables.S3_ACCESS_KEY,
                EnvironmentVariables.S3_SECRET_KEY
            );

            _s3 = new AmazonS3Client(
                credentials,
                new AmazonS3Config
                {
                    ServiceURL = EnvironmentVariables.S3_SERVICE_URL,
                    ForcePathStyle = true, // Essential for SeaweedFS
                    UseHttp = EnvironmentVariables.S3_SERVICE_URL.StartsWith("http://"), // Auto-detect HTTP/HTTPS
                    MaxErrorRetry = 3,
                    Timeout = TimeSpan.FromSeconds(30),
                }
            );

            // Ensure bucket exists on initialization
            EnsureBucketExistsAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Ensures the bucket exists, creates it if not
        /// SeaweedFS S3 stores buckets as directories in the filer
        /// </summary>
        private async Task EnsureBucketExistsAsync()
        {
            try
            {
                _logger.LogInformation($"Checking if bucket '{_bucket}' exists...");

                // For SeaweedFS, we need to check if the bucket exists by trying to list objects in it
                // ListBuckets may not work with SeaweedFS S3, so we use a different approach
                try
                {
                    // Try to list objects in the bucket - if it works, bucket exists
                    var listRequest = new ListObjectsV2Request
                    {
                        BucketName = _bucket,
                        MaxKeys = 1,
                    };

                    await _s3.ListObjectsV2Async(listRequest);
                    _logger.LogInformation($"Bucket '{_bucket}' exists.");
                }
                catch (AmazonS3Exception s3Ex)
                    when (s3Ex.ErrorCode == "NoSuchBucket"
                        || s3Ex.StatusCode == System.Net.HttpStatusCode.NotFound
                    )
                {
                    _logger.LogWarning($"Bucket '{_bucket}' does not exist. Creating it...");

                    // Create bucket - SeaweedFS will create it as a directory in the filer
                    await _s3.PutBucketAsync(
                        new PutBucketRequest { BucketName = _bucket, UseClientRegion = false }
                    );

                    _logger.LogInformation($"Bucket '{_bucket}' created successfully!");
                }
            }
            catch (AmazonS3Exception s3Ex)
            {
                _logger.LogError(s3Ex, $"S3 Error ensuring bucket exists: {s3Ex.Message}");
                _logger.LogError($"Error Code: {s3Ex.ErrorCode}");
                _logger.LogError($"Status Code: {s3Ex.StatusCode}");

                // Don't throw - allow service to continue even if bucket check fails
                // The upload will fail with a clearer error if bucket doesn't exist
                _logger.LogWarning(
                    $"Could not verify bucket existence. Will attempt to create on first upload. SeaweedFS may require filer configuration."
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error ensuring bucket exists: {ex.Message}");
                _logger.LogWarning(
                    $"Continuing without bucket verification. SeaweedFS will auto-create bucket on first upload if configured properly."
                );
            }
        }

        // ---------------------------------------------------------
        // UPLOAD
        // ---------------------------------------------------------
        public async Task<string> UploadAsync(IFormFile file, string? nestedFolder = null)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("File is empty or null");
                }
                var tmpKeyName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var key = nestedFolder is null ? tmpKeyName : $"{nestedFolder}/{tmpKeyName}";

                _logger.LogInformation(
                    $"Uploading file: {file.FileName} (Size: {file.Length} bytes, ContentType: {file.ContentType})"
                );
                _logger.LogInformation($"Generated key: {key}");

                using var stream = file.OpenReadStream();

                var request = new PutObjectRequest
                {
                    BucketName = _bucket,
                    Key = key,
                    InputStream = stream,
                    ContentType = file.ContentType ?? "application/octet-stream",
                    AutoCloseStream = false,
                    AutoResetStreamPosition = false,
                };

                var response = await _s3.PutObjectAsync(request);

                _logger.LogInformation($"Upload successful. ETag: {response.ETag}");

                return key;
            }
            catch (AmazonS3Exception s3Ex)
            {
                _logger.LogError(s3Ex, $"S3 Error uploading file: {s3Ex.Message}");
                _logger.LogError($"Error Code: {s3Ex.ErrorCode}");
                _logger.LogError($"Status Code: {s3Ex.StatusCode}");
                _logger.LogError($"Request ID: {s3Ex.RequestId}");

                throw new Exception(
                    $"SeaweedFS S3 error: {s3Ex.Message}. Error Code: {s3Ex.ErrorCode}",
                    s3Ex
                );
            }
            catch (System.Net.Http.HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, $"HTTP Error uploading file: {httpEx.Message}");
                _logger.LogError($"HTTP Status Code: {httpEx.StatusCode}");

                throw new Exception(
                    $"Cannot connect to SeaweedFS at {_publicUrl}. "
                        + $"Please verify SeaweedFS is running and accessible. "
                        + $"Details: {httpEx.Message}",
                    httpEx
                );
            }
            catch (TaskCanceledException tcEx) when (tcEx.InnerException is TimeoutException)
            {
                _logger.LogError(tcEx, $"Timeout uploading file: {tcEx.Message}");

                throw new Exception(
                    $"Upload timed out. SeaweedFS may be unresponsive or overloaded. "
                        + $"Details: {tcEx.Message}",
                    tcEx
                );
            }
            catch (System.IO.IOException ioEx)
                when (ioEx.Message.Contains("response ended prematurely")
                    || ioEx.Message.Contains("ResponseEnded")
                )
            {
                _logger.LogError(ioEx, $"SeaweedFS connection error: {ioEx.Message}");
                _logger.LogError(
                    $"This typically means SeaweedFS closed the connection unexpectedly."
                );
                _logger.LogError($"Possible causes:");
                _logger.LogError(
                    $"  1. SeaweedFS S3 gateway is not properly connected to the filer"
                );
                _logger.LogError(
                    $"  2. Bucket '{_bucket}' doesn't exist (create with: curl -X POST http://localhost:8888/{_bucket}/?pretty=y -d '{{}}')"
                );
                _logger.LogError($"  3. SeaweedFS is misconfigured or crashed");
                _logger.LogError($"  4. Network connectivity issues");

                throw new Exception(
                    $"SeaweedFS connection was closed prematurely. "
                        + $"This usually means: "
                        + $"1) The bucket '{_bucket}' doesn't exist (create it manually), or "
                        + $"2) S3 gateway is not connected to the filer, or "
                        + $"3) SeaweedFS crashed during upload. "
                        + $"Check SeaweedFS logs for more details.",
                    ioEx
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error uploading file: {ex.Message}");
                _logger.LogError($"Exception Type: {ex.GetType().FullName}");

                if (ex.InnerException != null)
                {
                    _logger.LogError($"Inner Exception: {ex.InnerException.GetType().FullName}");
                    _logger.LogError($"Inner Exception Message: {ex.InnerException.Message}");
                }

                throw new Exception($"Unexpected error uploading to SeaweedFS: {ex.Message}", ex);
            }
        }

        // ---------------------------------------------------------
        // DOWNLOAD (stream)
        // ---------------------------------------------------------
        public async Task<(Stream Stream, string ContentType)?> ReadAsync(string key)
        {
            try
            {
                _logger.LogInformation($"Reading file with key: {key}");

                var response = await _s3.GetObjectAsync(_bucket, key);

                _logger.LogInformation(
                    $"File retrieved successfully. ContentType: {response.Headers.ContentType}"
                );

                return (response.ResponseStream, response.Headers.ContentType);
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogWarning($"File not found: {key}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error reading file: {ex.Message}");
                throw;
            }
        }

        // ---------------------------------------------------------
        // DELETE
        // ---------------------------------------------------------
        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                _logger.LogInformation($"Deleting file with key: {key}");

                await _s3.DeleteObjectAsync(_bucket, key);

                _logger.LogInformation($"File deleted successfully: {key}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting file: {ex.Message}");
                return false;
            }
        }

        // ---------------------------------------------------------
        // URL PUBLIQUE (si SeaweedFS est exposé)
        // ---------------------------------------------------------
        public string GetPublicUrl(string key)
        {
            // SeaweedFS direct access through filer (no S3 auth needed)
            // Format: http://localhost:8888/bucketname/filename
            var filerUrl = _publicUrl.Replace(":8333", ":8888"); // Replace S3 port with Filer port
            return $"{filerUrl}/buckets/{_bucket}/{key}";
        }

        // ---------------------------------------------------------
        // URL SIGNÉE (accès sécurisé)
        // ---------------------------------------------------------
        public string GetSignedUrl(string key, int minutes = 60)
        {
            try
            {
                // For SeaweedFS, use filer URL for direct access instead of signed S3 URLs
                // SeaweedFS S3 signed URLs require proper IAM configuration
                // For development/simple setups, use filer direct access

                _logger.LogInformation($"Generating URL for key: {key}");

                // Option 1: Use filer direct access (recommended for simple setup)
                var filerUrl = _publicUrl.Replace(":8333", ":8888");
                var directUrl = $"{filerUrl}/buckets/{_bucket}/{key}";

                _logger.LogInformation($"Generated filer URL: {directUrl}");

                return directUrl;

                // Option 2: Generate S3 presigned URL (requires proper S3 config)
                // Uncomment this if you have proper S3 authentication configured:
                /*
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _bucket,
                    Key = key,
                    Expires = DateTime.UtcNow.AddMinutes(minutes),
                    Protocol = _publicUrl.StartsWith("https") ? Protocol.HTTPS : Protocol.HTTP
                };

                var url = _s3.GetPreSignedURL(request);
                _logger.LogInformation($"Generated signed S3 URL for key: {key}");
                return url;
                */
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error generating URL: {ex.Message}");

                // Fallback to filer URL
                var filerUrl = _publicUrl.Replace(":8333", ":8888");
                return $"{filerUrl}/{_bucket}/{key}";
            }
        }

        /// <summary>
        /// Test connection to SeaweedFS
        /// </summary>
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var buckets = await _s3.ListBucketsAsync();
                _logger.LogInformation(
                    $"Connection test successful. Found {buckets.Buckets.Count} buckets."
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Connection test failed: {ex.Message}");
                return false;
            }
        }
    }
}
