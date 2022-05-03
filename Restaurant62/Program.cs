using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.BLL.Impl;
using Restaurant62.DAL.Abstract.Repository;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl;
using Restaurant62.DAL.Impl.Context;
using Restaurant62.DAL.Impl.Repository;
using Restaurant62.DAL.Impl.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Entities.Enums;
using Restaurant62.Models;


var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();

var options = optionsBuilder
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;")
    .Options;

// RestaurantDbContext context = new RestaurantDbContext(options);

// IUnitOfWork unitOfWork = new UnitOfWork(context);

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.InstallRepositories();
serviceCollection.InstallMappers();
serviceCollection.InstallServices();

IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


IDishIngredientService? dishIngredientService = serviceProvider.GetService<IDishIngredientService>();
IDishService? dishService = serviceProvider.GetService<IDishService>();
IIngredientService? ingredientService = serviceProvider.GetService<IIngredientService>();
IOrderService? orderService = serviceProvider.GetService<IOrderService>();
IPricelistService? pricelistService = serviceProvider.GetService<IPricelistService>();
IDishOrderService? dishOrderService = serviceProvider.GetService<IDishOrderService>();


// IUnitOfWork? unitOfWork = serviceProvider.GetService<IUnitOfWork>();


//
// Ingredient ingredient1 = new Ingredient()
// {
//     Name = "ingr1"
// };
//
// Ingredient ingredient2 = new Ingredient()
// {
//     Name = "ingr2"
// };
//
// Ingredient ingredient3 = new Ingredient()
// {
//     Name = "ingr3"
// };

// unitOfWork.IngredientRepository.Add(ingredient1);
// unitOfWork.IngredientRepository.Add(ingredient2);
// unitOfWork.IngredientRepository.Add(ingredient3);
//
// unitOfWork.SaveChanges();
// Console.WriteLine("ingredients");
// foreach (var ingredient in unitOfWork.IngredientRepository.GetAll(x=>true))
// {
//     Console.WriteLine(ingredient.IngredientId);
//     Console.WriteLine(ingredient.Name);
// }
//
// Console.WriteLine("dishes");
// foreach (var ingredient in unitOfWork.DishRepository.GetAll(x=>true))
// {
//     Console.WriteLine(ingredient.DishId);
//     Console.WriteLine(ingredient.Name);
// }
//
// DishIngredient di1 = new DishIngredient()
// {
//     DishId = 8,
//     IngredientId = 1,
// };
//
// DishIngredient di2 = new DishIngredient()
// {
//     DishId = 8,
//     IngredientId = 2,
// };
//
// DishIngredient di3 = new DishIngredient()
// {
//     DishId = 9,
//     IngredientId = 2,
// };
//
// DishIngredient di4 = new DishIngredient()
// {
//     DishId = 9,
//     IngredientId = 3,
// };

// unitOfWork.DishIngredientRepository.Add(di1);
// unitOfWork.DishIngredientRepository.Add(di2);
// unitOfWork.DishIngredientRepository.Add(di3);
// unitOfWork.DishIngredientRepository.Add(di4);
//
// unitOfWork.SaveChanges();

// foreach (var d in unitOfWork.DishIngredientRepository.GetAll(x=>true))
// {
//     Console.WriteLine(d.DishId);
//     Console.WriteLine(d.IngredientId);
//     Console.WriteLine();
// }

// Pricelist p1 = new Pricelist()
// {
//     Name = "first one",
//     
// };
//
// Pricelist p2 = new Pricelist()
// {
//     Name = "second one",
//     
// };


//
// Dish dish8 = new Dish() { DishId = 8, PricelistId = 3, Name = "dish8"};
// Dish dish9 = new Dish() { DishId = 9, PricelistId = 4 , Name = "dish9"};
// Dish dish10 = new Dish() { DishId = 10, PricelistId = 4, Name = "dish10" };
//
// unitOfWork.DishRepository.Update(dish8);
// unitOfWork.DishRepository.Update(dish9);
// unitOfWork.DishRepository.Update(dish10);
//
//
//
//
// unitOfWork.SaveChanges();


// dishIngredientService

DishIngredientModel dishIngredient1 = new DishIngredientModel()
{
    DishId = 10,
    IngredientId = 1,
};

var dishIngredient2 = new DishIngredientModel()
{
    DishId = 10,
    IngredientId = 2,
};

var dishIngredient3 = new DishIngredientModel()
{
    DishId = 10,
    IngredientId = 3,
};
//
// dishIngredientService?.Create(dishIngredient1);
// dishIngredientService?.Create(dishIngredient2);
// dishIngredientService?.Create(dishIngredient3);


var dish8 = new DishModel()
{
    DishId = 8,
    Name = "dish8",
    Potion = PortionSize.OneHundredGram,
    PricePer100G = 100,
    PricelistId = 3,
};

var dish9 = new DishModel()
{
    DishId = 9,
    Name = "dish9",
    Potion = PortionSize.TwoHundredGram,
    PricePer100G = 200,
    PricelistId = 4,
};

var dish10 = new DishModel()
{
    DishId = 10,
    Name = "dish10",
    Potion = PortionSize.ThreeHundredGram,
    PricePer100G = 300,
    PricelistId = 4,
};

// dishService?.Update(dish8);
// dishService?.Update(dish9);
// dishService?.Update(dish10);

OrderModel orderModel1 = new OrderModel() { OrderId = 1 };

// orderService.Create(orderModel1);
// orderService?.Update(orderModel1);

DishOrderModel dishOrderModel1 = new DishOrderModel()
{
    OrderId = 1,
    DishId = 8,
};

DishOrderModel dishOrderModel2 = new DishOrderModel()
{
    OrderId = 1,
    DishId = 9,
};
// dishOrderService.Create(dishOrderModel1);
// dishOrderService.Create(dishOrderModel2);


// order of dishes M:N
Console.WriteLine("order of dishes M:N");

var dishOrders = dishOrderService.GetAll();
var dishes3 = dishService.GetAll();
var orders = orderService.GetAll();

var orderIds = dishOrders.GroupBy(d => d.OrderId, i => i.DishId);

foreach (var o in orderIds)
{
    // d.Key
    OrderModel? order = orders.FirstOrDefault(x => x.OrderId == o.Key);
    Console.WriteLine("OrderID: " + order?.OrderId);
    foreach (var i in o)
    {
        var dishModel = dishes3.FirstOrDefault(x => x.DishId == i);
        Console.WriteLine(
            $"\t  DishID: {dishModel.DishId},  Name: {dishModel.Name},  FinalPrice: {dishModel.FinalPrice} ");
    }

    Console.WriteLine("Order Price: " + order.OrderPrice);
    Console.WriteLine();
}

Console.WriteLine(new string('-', 50));

// pricelists to dishes 1:N. succeed
Console.WriteLine("Pricelists to dishes 1:N. succeed:");
foreach (var p in pricelistService.GetAll())
{
    Console.WriteLine("Pricelist: " + p.Name + " :");
    var item = dishService.GetAll().Where(x => x.PricelistId == p.PricelistId);
    foreach (var i in item)
    {
        Console.WriteLine($"\t  DishId: {i.DishId}, Name: {i.Name}, Potion: {i.Potion}, " +
                          $"PricePer100G: {i.PricePer100G}, FinalPrice: {i.FinalPrice} ");
    }

    Console.WriteLine();
}

Console.WriteLine(new string('-', 50));

// dishes to ingredients M:N
Console.WriteLine("dishes to ingredients M:N");

var dishIngredients = dishIngredientService.GetAll();
var dishes = dishService.GetAll();
var ingredients = ingredientService.GetAll();

var dishesIds = dishIngredients.GroupBy(d => d.DishId, i => i.IngredientId).ToList();

foreach (var d in dishesIds)
{
    // d.Key
    var dish = dishes.FirstOrDefault(x => x.DishId == d.Key);
    Console.WriteLine(dish.DishId + " " + dish.Name);
    foreach (var i in d)
    {
        var ingr = ingredients.FirstOrDefault(x => x.IngredientId == i);
        Console.WriteLine("\t" + ingr.IngredientId + " " + ingr.Name);
    }

    Console.WriteLine();
}

//
//
// var result = dishIngredients.Where(x => x.DishId == 8).Select(x => x.IngredientId);
//
// var ingrs = unitOfWork.IngredientRepository.GetAll(x => true);
//
// foreach (var i in ingrs)
// {
//     foreach (var resint in result)
//     {
//         if (i.IngredientId == resint)
//         {
//             Console.WriteLine(i.IngredientId);
//             Console.WriteLine(i.Name);
//             
//         }
//     }
// }


//
// foreach (var p in unitOfWork.PriceListRepository.GetAll(x=>true))
// {
//     Console.WriteLine(p.Name);
//     foreach (var d in p.Dishes)
//     {
//         d.Name
//     }
// }


// context.Dispose();
Console.WriteLine(new string('-', 50));
Console.WriteLine("hi");