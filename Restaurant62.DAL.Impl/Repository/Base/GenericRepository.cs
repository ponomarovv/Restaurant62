using Microsoft.EntityFrameworkCore;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl.Context;

namespace Restaurant62.DAL.Impl.Repository.Base;

public abstract class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity> where TEntity : class
{
    private readonly RestaurantDbContext _context;

    public DbSet<TEntity> DbSet => _context.Set<TEntity>();

    protected GenericRepository(RestaurantDbContext dbContext)
    {
        _context = dbContext;
    }

    public TEntity Add(TEntity entity)
    {
        var item = DbSet.Add(entity).Entity;
        // _context.SaveChanges();
        return item;
    }

    public bool Delete(TKey key)
    {
        TEntity item = DbSet.Find(key);
        if (item == null)
        {
            return false;
        }

        DbSet.Remove(item);
        // _context.SaveChanges();
        return true;
    }

    public virtual bool Update(TEntity entity)
    {
        if (entity == null)
        {
            return false;
        }

        // DbSet.Find(entity.)

        DbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        // _context.SaveChanges();
        return true;
    }

    public List<TEntity> GetAll(Func<TEntity, bool> predicate)
    {
        List<TEntity> items = DbSet.Where(predicate).ToList();
        return items;
    }

    public TEntity GetById(TKey key)
    {
        TEntity item = DbSet.Find(key);
        return item;
    }
}