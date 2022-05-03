namespace Restaurant62.Entities;

public class Order
{
    public int OrderId { get; set; }
    
    public decimal? OrderPrice { get; set; }
    
    // M:N dish:orders
    public IList<DishOrder> DishOrders { get; set; }

}