namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBCategoryRepo BCategories { get; }
        IBProductRepo BProducts { get; }

        IOrderRepo Orders { get; }

        Task SaveAsync();
    }
}
