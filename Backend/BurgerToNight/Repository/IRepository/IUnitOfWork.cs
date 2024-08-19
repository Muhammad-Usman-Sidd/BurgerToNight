namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepo Categories { get; }
        IProductRepo Products { get; }
        IOrderDetailRepo OrderDetails { get; }

        IOrderHeaderRepo OrderHeaders { get; }
        ICartRepo Carts { get; }
        Task SaveAsync();
    }
}
