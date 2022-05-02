namespace Restaurant62.BLL.Abstract.Mappers;

public interface IMapper<TEntity, TModel>
{
    TModel Map(TEntity entity);
}