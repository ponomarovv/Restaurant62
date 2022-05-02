using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;


public class IngredientMapper:IBackMapper<Ingredient ,IngredientModel>
{
    // private DishMapper _dishMapper = new DishMapper();
    
    public IngredientModel Map(Ingredient entity)
    {

        
        return new IngredientModel()
        {
            IngredientId  = entity.IngredientId,
            // Dishes = ModelDishes,
            Name = entity.Name,
        };
    }

    public Ingredient MapBack(IngredientModel model)
    {
 
        
        return new Ingredient()
        {
            IngredientId = model.IngredientId,
            // Dishes = EntityDishes,
            Name = model.Name
        };
    }
}