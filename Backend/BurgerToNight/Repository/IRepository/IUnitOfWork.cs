namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBCategoryRepo BCategories { get; }
        IBProductRepo BProducts { get; }
        IOrderItemRepo OrderItems { get; }
        IOrderDetailRepo OrderDetails { get; }

        Task SaveAsync();
    }
}
