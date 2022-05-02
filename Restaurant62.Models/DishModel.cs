using Restaurant62.Entities;

namespace Restaurant62.Models;

public class DishModel
{
    public int DishId { get; set; }
    public string Name { get; set; }
    
    public decimal PricePer100G { get; set; }
    public decimal? FinalPrice { get; set; }
    
    // 1:N Pricelist : Dish
   
    public int? PricelistId { get; set; }
    
}
