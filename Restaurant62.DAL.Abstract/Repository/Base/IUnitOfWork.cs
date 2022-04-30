namespace Restaurant62.DAL.Abstract.Repository.Base;

public interface IUnitOfWork : IDisposable
{
    IDishRepository DishRepository { get; }
    IIngredientRepository IngredientRepository { get; }
    IOrderRepository OrderRepository { get; }
    IPricelistRepository PriceListRepository { get; }

    // IDishEntityIngredientEntityRepository DishEntityIngredientEntityRepository { get; }
    // IDishEntityOrderEntityRepository DishEntityOrderEntityRepository { get; }

    void SaveChanges();
}