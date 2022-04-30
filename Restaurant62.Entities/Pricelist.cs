namespace Restaurant62.Entities;

public class Pricelist
{
    public int PricelistId { get; set; }
    
    public string Name { get; set; }
    
    // 1:M Pricelist:dishes
    public List<Dish> Dishes { get; set; }
}