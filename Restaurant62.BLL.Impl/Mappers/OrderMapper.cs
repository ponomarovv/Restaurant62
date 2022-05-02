using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;


public class OrderMapper : IBackMapper<Order , OrderModel>
{
    // private DishMapper _dishMapper = new DishMapper();
    public OrderModel Map(Order entity)
    {

        
        return new OrderModel()
        {
            OrderId = entity.OrderId,
            // Dishes = ModelDishes
          
        };
    }

    public Order MapBack(OrderModel model)
    {

        
        return new Order()
        {
            OrderId = model.OrderId,
            // Dishes = DishesEntities
        };
    }
}