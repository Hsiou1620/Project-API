using Azure.Storage.Blobs;
using game_shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace game_shop.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class BlobFileUpload(IBlobService blobService) : ControllerBase
    {
        private readonly IBlobService _blobService = blobService;

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            try
            {
                await _blobService.UploadAsync(file);
                return Ok(new { file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
    }
}
