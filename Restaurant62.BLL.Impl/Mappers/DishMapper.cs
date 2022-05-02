using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;

public class DishMapper : IBackMapper<Dish, DishModel>
{
    private IBackMapper<Ingredient, IngredientModel> _ingredientMapper;
    private IBackMapper<Order, OrderModel> _orderMapper;

    public DishMapper(IBackMapper<Ingredient, IngredientModel> ingredientMapper,
        IBackMapper<Order, OrderModel> orderMapper)
    {
        _ingredientMapper = ingredientMapper;
        _orderMapper = orderMapper;
    }

    public DishModel Map(Dish entity)
    {
        return new DishModel()
        {
            DishId = entity.DishId,

            Name = entity.Name,
            Potion = entity.Potion,
            PricePer100G = entity.PricePer100G,
            FinalPrice = entity.FinalPrice,


            // Ingredients = ingredientsModel,
            // Orders = ordersModel,
            PricelistId = entity.PricelistId,
        };
    }

    public Dish MapBack(DishModel model)
    {
        return new Dish()
        {
            DishId = model.DishId,

            Name = model.Name,
            Potion = model.Potion,

            PricePer100G = model.PricePer100G,

            FinalPrice = model.FinalPrice,


            // Ingredients = ingredientsEntity,
            // Orders = orderesEntity,
            PricelistId = model.PricelistId,
        };
    }
}