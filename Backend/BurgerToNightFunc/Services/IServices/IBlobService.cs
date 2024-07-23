using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Services.IServices
{
    public interface IBlobService
    {
        Task<string> UploadBase64ImageAsync(string base64Image);
        Task<string> DownloadBlobAsBase64Async(string blobName);
        Task DeleteBlobAsync(string blobName);
    }
}
