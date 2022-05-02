using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Mappers;

public class DishOrderMapper : IBackMapper<DishOrder, DishOrderModel>
{
    public DishOrderModel Map(DishOrder entity)
    {
        return new DishOrderModel()
        {
            DishOrderId = entity.DishOrderId,
            DishId = entity.DishId,
            OrderId = entity.OrderId,
        };
    }

    public DishOrder MapBack(DishOrderModel model)
    {
        return new DishOrder()
        {
            DishOrderId = model.DishOrderId,
            DishId = model.DishId,
            OrderId = model.OrderId,
        };
    }
}