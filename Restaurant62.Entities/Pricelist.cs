namespace Restaurant62.Entities;

public class PRICELISTasdfasdfasdf
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    // 1:M Pricelist:dishes
    public List<Dish> Dishes { get; set; }
}