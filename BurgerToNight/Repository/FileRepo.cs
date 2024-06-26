using BurgerToNight.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BurgerToNightAPI.Repository
{
    public class FileRepo : IFileRepo
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileRepo(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            string fileExtension = Path.GetExtension(file.FileName)?.ToLower();

            string[] allowedFileExtensions = { ".png", ".jpg", ".jpeg" };
            if (fileExtension == null || !allowedFileExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file extension");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to save the file", ex);
            }

            return uniqueFileName;
        }

        public Task<bool> DeleteFile(string existingImage)
        {
            if (string.IsNullOrEmpty(existingImage))
            {
                throw new ArgumentNullException(nameof(existingImage));
            }

            var path = _webHostEnvironment.ContentRootPath;
            var mainPath = Path.Combine(path, "images", existingImage);

            if (!File.Exists(mainPath))
            {
                throw new FileNotFoundException("Invalid file address");
            }

            File.Delete(mainPath);
            return Task.FromResult(true);
        }
    }
}
