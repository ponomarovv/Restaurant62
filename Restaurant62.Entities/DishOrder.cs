using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Entities;

public class DishOrder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DishOrderId { get; set; }
    public int DishId { get; set; }
    public Dish Dish { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
}