using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;

namespace Restaurant62.DAL.Abstract.Repository;

public interface IDishRepository : IGenericRepository<int, Dish>
{
}