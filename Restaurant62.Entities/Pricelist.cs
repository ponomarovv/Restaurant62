using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Entities;

public class Pricelist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PricelistId { get; set; }

    public string Name { get; set; }

    // 1:M Pricelist:dishes
    public List<Dish> Dishes { get; set; }
}