namespace Restaurant62.Entities;

public class Ingredient
{
    public int IngredientId { get; set; }
    
    public string Name { get; set; }
    
    public IList<DishIngredient> DishIngredients { get; set; }
}