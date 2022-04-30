using Microsoft.EntityFrameworkCore;
using Restaurant62.Entities;

namespace Restaurant62.DAL.Impl.Context;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext()
    {
    }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddDbContext<BloggingContext>(options => options.UseSqlite("Data Source=blog.db"));
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)// Crée la migration
    {
        modelBuilder.Entity<Dish>().Property(p => p.PricePer100G).HasColumnType("decimal(18,4)");
        modelBuilder.Entity<Dish>().Property(p => p.FinalPrice).HasColumnType("decimal(18,4)");

    }



    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pricelist> PriceLists { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<DishOrder> DishOrders { get; set; }

    public void Dispose()
    {
        base.Dispose();
    }
}

