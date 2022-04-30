﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant62.Entities;

public class Dish
{
    public int DishId { get; set; }
    public string Name { get; set; }
    
    public decimal PricePer100G { get; set; }
    public decimal? FinalPrice { get; set; }
    
    // 1:N Pricelist : Dish
    [ForeignKey("PricelistId")] 
    public int? PricelistId { get; set; }
    public Pricelist Pricelist { get; set; }
    
    // M:N dish:ingredients
    public IList<DishIngredient> DishIngredients { get; set; }
    
    // M:N dish:orders
    public IList<DishOrder> DishOrders { get; set; }
}