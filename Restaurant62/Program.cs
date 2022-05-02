using Microsoft.EntityFrameworkCore;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl.Context;
using Restaurant62.DAL.Impl.Repository;
using Restaurant62.DAL.Impl.Repository.Base;
using Restaurant62.Entities;


var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();

var options = optionsBuilder
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;")
    .Options;

RestaurantDbContext context = new RestaurantDbContext(options);

IUnitOfWork unitOfWork = new UnitOfWork(context);
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


// pricelists to dishes 1:N. succeed
Console.WriteLine("pricelists to dishes 1:N. succeed:");
foreach (var p in unitOfWork.PriceListRepository.GetAll(x => true))
{
    Console.WriteLine("Pricelist: " + p.Name + " :");
    var item = unitOfWork.DishRepository.GetAll(x => x.PricelistId == p.PricelistId);
    foreach (var i in item)
    {
        Console.WriteLine("\t" + i.Name);
    }

    Console.WriteLine();
}

Console.WriteLine(new string('-', 50));
Console.WriteLine();

// dishes to ingredients M:N
Console.WriteLine("dishes to ingredients M:N");

var dishIngredients = unitOfWork.DishIngredientRepository.GetAll(x => true);
var dishes = unitOfWork.DishRepository.GetAll(x => true);
var ingredients = unitOfWork.IngredientRepository.GetAll(x => true);

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


context.Dispose();
Console.WriteLine(new string('-', 50));
Console.WriteLine("hi");