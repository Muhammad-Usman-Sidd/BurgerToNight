namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBCategoryRepo BCategories { get; }
        IBProductRepo BProducts { get; }
        IOrderDetailRepo OrderDetails { get; }

        IOrderHeaderRepo OrderHeaders { get; }
        ICartRepo Carts { get; }
        Task SaveAsync();
    }
}
