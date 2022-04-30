using Restaurant62.DAL.Abstract.Repository;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl.Context;

namespace Restaurant62.DAL.Impl.Repository.Base;


public class UnitOfWork : IUnitOfWork
{
    private RestaurantDbContext _context;

    public IDishRepository DishRepository { get; }
    public IIngredientRepository IngredientRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IPricelistRepository PriceListRepository { get; }

    public IDishIngredientRepository DishIngredientRepository { get; }
    public IDishOrderRepository DishOrderRepository { get; }

    public UnitOfWork(
        RestaurantDbContext context
    )
    {
        _context = context;

        DishRepository = new DishRepository(_context);
        IngredientRepository = new IngredientRepository(_context);
        OrderRepository = new OrderRepository(_context);
        PriceListRepository = new PricelistRepository(_context);

        DishIngredientRepository = new DishIngredientRepository(_context);
        DishOrderRepository = new DishOrderRepository(_context);
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    private bool disposed = false;

    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}