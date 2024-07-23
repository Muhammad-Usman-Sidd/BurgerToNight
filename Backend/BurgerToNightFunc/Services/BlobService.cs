using Azure.Storage.Blobs;
using BurgerToNightFunc.Services.IServices;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "images";

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        private string GenerateBlobName()
        {
            return ("Blob"+Guid.NewGuid().ToString());
        }

        public async Task<string> UploadBase64ImageAsync(string base64Image)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await containerClient.CreateIfNotExistsAsync();

                // Extract base64 data and decode
                var base64Data = base64Image.Split(',')[1];
                var byteArray = Convert.FromBase64String(base64Data);

                // Generate a unique blob name
                var blobName = GenerateBlobName();
                var blobClient = containerClient.GetBlobClient(blobName);

                // Upload the image as a binary stream
                using (var ms = new MemoryStream(byteArray))
                {
                    await blobClient.UploadAsync(ms, true);
                }

                // Return the blob name
                return blobName;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                throw new Exception("Error uploading image to Blob Storage", ex);
            }
        }

        public async Task<string> DownloadBlobAsBase64Async(string blobName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                var blobClient = containerClient.GetBlobClient(blobName);

                var downloadResponse = await blobClient.DownloadAsync();
                using (var memoryStream = new MemoryStream())
                {
                    await downloadResponse.Value.Content.CopyToAsync(memoryStream);

                    // Convert the image to base64
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());
                    return $"{base64String}";
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                throw new Exception("Error downloading blob as base64", ex);
            }
        }
        public async Task DeleteBlobAsync(string blobName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                var blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting blob", ex);
            }
        }
    }
}
