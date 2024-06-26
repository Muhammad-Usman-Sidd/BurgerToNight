using BurgerToNightUI.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace BurgerToNightUI.Services
{
    public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
    {

        public async Task<string> SaveFile(IFormFile Image)
        {
            if (Image == null)
            {
                throw new ArgumentNullException();
            }
            var path = webHostEnvironment.ContentRootPath;
            var mainPath = Path.Combine(path, "images");
            //validating if folder/directory is already created or not
            if (!Directory.Exists(mainPath))
            {
                Directory.CreateDirectory(mainPath);
            }
            var ext = Path.GetExtension(Image.FileName);
            string[] allowedFileExtensions = [".png", "png", ".jpg", "jpg", ".jpeg", "jpeg"];
            if (!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException();
            }
            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNamePath = Path.Combine(mainPath, fileName);
            var stream = new FileStream(fileNamePath, FileMode.Create);
            await Image.CopyToAsync(stream);
            return fileName;
        }


        public Task<string> DeleteFile(string ExistingImage)
        {
            if (ExistingImage.ToString().IsNullOrEmpty())
            {
                throw new ArgumentNullException();
            }
            var path = webHostEnvironment.ContentRootPath;
            var mainPath = Path.Combine(path, $"images",ExistingImage);

            if (!File.Exists(mainPath))
            {
                throw new FileNotFoundException($"Invalid File Address");
            }
            File.Delete(mainPath);
            return null; 
        }
    }
}
