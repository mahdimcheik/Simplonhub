using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using SimplonHubApi.Utilities;
namespace SimplonHubApi.Services
{


    public class SeaweedStorageService
    {
        private readonly IAmazonS3 _s3;
        private readonly string _bucket;
        private readonly string _publicUrl;

        public SeaweedStorageService(IConfiguration config)
        {
            var section = config.GetSection("Seaweed");

            _bucket = EnvironmentVariables.S3_BUCKET;
            _publicUrl = EnvironmentVariables.S3_SERVICE_URL;

            var credentials = new BasicAWSCredentials(
                EnvironmentVariables.S3_ACCESS_KEY,
                EnvironmentVariables.S3_SECRET_KEY
            );

            _s3 = new AmazonS3Client(credentials, new AmazonS3Config
            {
                ServiceURL = EnvironmentVariables.S3_SERVICE_URL,
                ForcePathStyle = true
            });
        }

        // ---------------------------------------------------------
        // UPLOAD
        // ---------------------------------------------------------
        public async Task<string> UploadAsync(IFormFile file)
        {
            var key = Guid.NewGuid().ToString();

            using var stream = file.OpenReadStream();

            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = key,
                InputStream = stream,
                ContentType = file.ContentType
            };

            await _s3.PutObjectAsync(request);

            return key;
        }

        // ---------------------------------------------------------
        // DOWNLOAD (stream)
        // ---------------------------------------------------------
        public async Task<(Stream Stream, string ContentType)?> ReadAsync(string key)
        {
            try
            {
                var response = await _s3.GetObjectAsync(_bucket, key);
                return (response.ResponseStream, response.Headers.ContentType);
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        // ---------------------------------------------------------
        // DELETE
        // ---------------------------------------------------------
        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                await _s3.DeleteObjectAsync(_bucket, key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ---------------------------------------------------------
        // URL PUBLIQUE (si SeaweedFS est exposé)
        // ---------------------------------------------------------
        public string GetPublicUrl(string key)
        {
            return $"{_publicUrl}/{_bucket}/{key}";
        }

        // ---------------------------------------------------------
        // URL SIGNÉE (accès sécurisé)
        // ---------------------------------------------------------
        public string GetSignedUrl(string key, int minutes = 60)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucket,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(minutes)
            };

            return _s3.GetPreSignedURL(request);
        }
    }

}
