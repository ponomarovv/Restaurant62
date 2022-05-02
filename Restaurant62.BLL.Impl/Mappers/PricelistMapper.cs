using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;

public class PricelistMapper : IBackMapper<Pricelist , PricelistModel>
{
    public PricelistModel Map(Pricelist entity)
    {
        return new PricelistModel()
        {
            PricelistId = entity.PricelistId,
            Name = entity.Name,
            
            
        };
    }

    public Pricelist MapBack(PricelistModel model)
    {
        return new Pricelist()
        {
            PricelistId = model.PricelistId,
            Name = model.Name,
        };
    }
}