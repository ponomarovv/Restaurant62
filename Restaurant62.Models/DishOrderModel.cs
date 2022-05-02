using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Models;

public class DishOrderModel
{

    public int DishOrderId { get; set; }
    public int DishId { get; set; }
    
    public int OrderId { get; set; }
}