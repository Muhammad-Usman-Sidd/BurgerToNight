namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBCategoryRepo BCategories { get; }
        IBProductRepo BProducts { get; }


        Task SaveAsync();
    }
}
