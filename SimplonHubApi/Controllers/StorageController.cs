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

        public StorageController(SeaweedStorageService storage)
        {
            _storage = storage;
        }

        // UPLOAD
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var key = await _storage.UploadAsync(file);

            return Ok(new
            {
                key,
                publicUrl = _storage.GetPublicUrl(key),
                signedUrl = _storage.GetSignedUrl(key)
            });
        }

        // READ / STREAM
        [HttpGet("file/{key}")]
        public async Task<IActionResult> GetFile(string key)
        {
            var result = await _storage.ReadAsync(key);
            if (result == null)
                return NotFound();

            return File(result.Value.Stream, result.Value.ContentType);
        }

        // DELETE
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var ok = await _storage.DeleteAsync(key);
            if (!ok) return BadRequest();

            return Ok();
        }

        // URL SIGNÉE
        [HttpGet("signed-url/{key}")]
        public IActionResult GetSignedUrl(string key)
        {
            return Ok(new { url = _storage.GetSignedUrl(key) });
        }
    }

}
