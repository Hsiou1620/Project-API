using Azure.Storage.Blobs;
using Azure.Storage.Sas;
namespace game_shop.Services
{
    public class BlobService : IBlobService
    {
        private readonly string _containerName;
        private readonly string _connectionString;
        public BlobService(string connectionString, string containerName)
        {
            _connectionString = connectionString;
            _containerName = containerName;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "No file uploaded.";

            var blobServiceClient = new BlobServiceClient(_connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            await blobContainerClient.CreateIfNotExistsAsync();
            await blobContainerClient.UploadBlobAsync(file.FileName, stream);
            return blobContainerClient.Uri.ToString() + "/" + file.FileName;
        }
        
        public async Task<string> BlobSasBuilder()
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var blobContainerClient =  blobServiceClient.GetBlobContainerClient(_containerName);
            BlobSasBuilder blobSasBuilder = new BlobSasBuilder() { StartsOn = DateTime.UtcNow, ExpiresOn = DateTime.UtcNow.AddMonths(1), Resource = "c" };
            blobSasBuilder.SetPermissions(BlobAccountSasPermissions.Read);
            var sasUri = blobContainerClient.GenerateSasUri(blobSasBuilder).ToString();
            var sasToken = sasUri.Substring(sasUri.IndexOf('?') + 1);

            return sasToken;
        }
    }
}