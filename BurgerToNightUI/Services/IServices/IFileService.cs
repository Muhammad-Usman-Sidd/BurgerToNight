namespace BurgerToNightUI.Services.IServices
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile Image);
        Task<string> DeleteFile(string ExistingImage);
    }
}
