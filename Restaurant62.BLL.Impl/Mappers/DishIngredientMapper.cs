using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;

public class DishIngredientMapper : IBackMapper<DishIngredient , DishIngredientModel>
{
    public DishIngredientModel Map(DishIngredient entity)
    {
        return new DishIngredientModel()
        {
            DishIngredientId = entity.DishIngredientId,
            IngredientId = entity.IngredientId,
            DishId = entity.DishId
        };
    }

    public DishIngredient MapBack(DishIngredientModel model)
    {
        return new DishIngredient() 
        {
            DishIngredientId = model.DishIngredientId,
            IngredientId = model.IngredientId,
            DishId = model.DishId
        };
    }
}