namespace game_shop.Services
{
    public interface IBlobService
    {
        Task<string> UploadAsync(IFormFile file);
        Task<string> BlobSasBuilder();
    }
}
