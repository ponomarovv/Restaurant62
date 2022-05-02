using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Models;

public class DishIngredientModel
{

    public int DishIngredientId { get; set; }
    public int DishId { get; set; }
   
    
    public int IngredientId { get; set; }
    
}