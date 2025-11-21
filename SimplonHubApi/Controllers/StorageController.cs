using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplonHubApi.Services;

namespace SimplonHubApi.Controllers
{
    [ApiController]
    [Route("api/storage")]
    public class StorageController : ControllerBase
    {
        private readonly SeaweedStorageService _storage;
        private readonly ILogger<StorageController> _logger;

        public StorageController(SeaweedStorageService storage, ILogger<StorageController> logger)
        {
            _storage = storage;
            _logger = logger;
        }

        /// <summary>
        /// Test connection to SeaweedFS
        /// </summary>
        [HttpGet("health")]
        public async Task<IActionResult> Health()
        {
            var isConnected = await _storage.TestConnectionAsync();
            
            if (isConnected)
            {
                return Ok(new { status = "healthy", message = "SeaweedFS is accessible" });
            }
            
            return StatusCode(503, new { status = "unhealthy", message = "Cannot connect to SeaweedFS" });
        }

        /// <summary>
        /// Upload a file to SeaweedFS
        /// </summary>
        /// <param name="file">The file to upload</param>
        [HttpPost("upload")]
        [RequestSizeLimit(100_000_000)] // 100MB limit
        [RequestFormLimits(MultipartBodyLengthLimit = 100_000_000)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { error = "No file provided or file is empty" });
                }

                _logger.LogInformation($"Received upload request for file: {file.FileName} ({file.Length} bytes)");

                var key = await _storage.UploadAsync(file);

                var response = new
                {
                    success = true,
                    key,
                    fileName = file.FileName,
                    size = file.Length,
                    contentType = file.ContentType,
                    publicUrl = _storage.GetPublicUrl(key),
                    signedUrl = _storage.GetSignedUrl(key)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error uploading file: {ex.Message}");
                return StatusCode(500, new { error = "Failed to upload file", message = ex.Message });
            }
        }

        /// <summary>
        /// Download/Stream a file from SeaweedFS
        /// </summary>
        /// <param name="key">The file key</param>
        [HttpGet("file/{key}")]
        public async Task<IActionResult> GetFile(string key)
        {
            try
            {
                var result = await _storage.ReadAsync(key);
                
                if (result == null)
                {
                    return NotFound(new { error = "File not found", key });
                }

                return File(result.Value.Stream, result.Value.ContentType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving file: {ex.Message}");
                return StatusCode(500, new { error = "Failed to retrieve file", message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a file from SeaweedFS
        /// </summary>
        /// <param name="key">The file key</param>
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            try
            {
                var success = await _storage.DeleteAsync(key);
                
                if (!success)
                {
                    return BadRequest(new { error = "Failed to delete file", key });
                }

                return Ok(new { success = true, message = "File deleted successfully", key });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting file: {ex.Message}");
                return StatusCode(500, new { error = "Failed to delete file", message = ex.Message });
            }
        }

        /// <summary>
        /// Get a signed URL for a file
        /// </summary>
        /// <param name="key">The file key</param>
        /// <param name="minutes">Expiration time in minutes (default: 60)</param>
        [HttpGet("signed-url/{key}")]
        public IActionResult GetSignedUrl(string key, [FromQuery] int minutes = 60)
        {
            try
            {
                var url = _storage.GetSignedUrl(key, minutes);
                
                return Ok(new 
                { 
                    url, 
                    key,
                    expiresIn = minutes,
                    expiresAt = DateTime.UtcNow.AddMinutes(minutes)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error generating signed URL: {ex.Message}");
                return StatusCode(500, new { error = "Failed to generate signed URL", message = ex.Message });
            }
        }

        /// <summary>
        /// Get public URL for a file
        /// </summary>
        /// <param name="key">The file key</param>
        [HttpGet("public-url/{key}")]
        public IActionResult GetPublicUrl(string key)
        {
            var url = _storage.GetPublicUrl(key);
            return Ok(new { url, key });
        }
    }
}
