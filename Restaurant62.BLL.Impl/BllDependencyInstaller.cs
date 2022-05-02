using Microsoft.Extensions.DependencyInjection;
using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.BLL.Impl.Mappers;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl;

public static class BllDependencyInstaller
{
    public static void InstallServices(this IServiceCollection services)
    {
        services.AddTransient<IDishService, DishService>();
        services.AddTransient<IIngredientService, IngredientService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IPriceListService, PriceListService>();
        
        services.AddTransient<IDishIngredientService, DishIngredientService>();
        services.AddTransient<IDishOrderService, DishOrderService>();
    }

    public static void InstallMappers(this IServiceCollection services)
    {
        services.AddTransient<IBackMapper<Dish , DishModel>, DishMapper>();
        services.AddTransient<IBackMapper<Ingredient , IngredientModel>, IngredientMapper>();
        services.AddTransient<IBackMapper<Order , OrderModel>, OrderMapper>();
        services.AddTransient<IBackMapper<Pricelist , PricelistModel>, PricelistMapper>();
        
        services.AddTransient<IBackMapper<DishIngredient, DishIngredientModel>, DishIngredientMapper>();
        services.AddTransient<IBackMapper<DishOrder, DishOrderModel>, DishOrderMapper>();
    }
}