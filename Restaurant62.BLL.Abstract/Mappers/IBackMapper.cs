namespace Restaurant62.BLL.Abstract.Mappers;

public interface IBackMapper<TEntity, TModel> : IMapper<TEntity, TModel>
{
    TEntity MapBack(TModel model);
}