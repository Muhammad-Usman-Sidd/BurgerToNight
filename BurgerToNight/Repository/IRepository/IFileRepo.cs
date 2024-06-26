namespace BurgerToNight.Repository.IRepository
{ 
    public interface IFileRepo
    {
        Task<string> SaveFile(IFormFile Image);
        Task<bool> DeleteFile(string ExistingImage);
    }
}
