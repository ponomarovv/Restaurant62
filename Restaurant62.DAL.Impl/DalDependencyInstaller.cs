using Microsoft.Extensions.DependencyInjection;
using Restaurant62.DAL.Abstract.Repository;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl.Context;
using Restaurant62.DAL.Impl.Repository;
using Restaurant62.DAL.Impl.Repository.Base;

namespace Restaurant62.DAL.Impl;

public static class DalDependencyInstaller
{
    public static void InstallRepositories(this IServiceCollection services)
    {
        services.AddScoped<RestaurantDbContext, RestaurantDbContext>();
        
        services.AddTransient<IDishRepository, DishRepository>();
        services.AddTransient<IIngredientRepository, IngredientRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IPricelistRepository, PricelistRepository>();
        
        services.AddTransient<IDishIngredientRepository, DishIngredientRepository>();
        services.AddTransient<IDishOrderRepository, DishOrderRepository>();
        
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        
    }
}