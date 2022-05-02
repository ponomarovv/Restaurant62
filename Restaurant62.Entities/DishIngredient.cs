using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Entities;

public class DishIngredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DishIngredientId { get; set; }
    
    public int DishId { get; set; }
    public Dish Dish { get; set; }
    
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}