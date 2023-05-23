

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductCard
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        
        ProductCard[] cards = {
            new() { Product = new Product { Name = "Apple", Price = 0.5m }, Quantity = 3 },
            new() { Product = new Product { Name = "Banana", Price = 0.3m }, Quantity = 2 },
            new() { Product = new Product { Name = "Orange", Price = 0.4m }, Quantity = 4 },
            new() { Product = new Product { Name = "Grapes", Price = 0.6m }, Quantity = 1 }
            
        };

        var sumOfAllProducts = cards.Sum(card => card.Product.Price * card.Quantity);


        Console.WriteLine($"Sum of all products: {sumOfAllProducts}");

        var sumsOfProductsPerBasket = new decimal[cards.Length];

        
        Parallel.For(0, cards.Length, i =>
        {
            sumsOfProductsPerBasket[i] = cards[i].Product.Price * cards[i].Quantity;
        });

        var sumOfProductsPerBasket = sumsOfProductsPerBasket.Sum();


        Console.WriteLine($"Sum of products per basket: {sumOfProductsPerBasket}");

        Console.ReadLine();
    }
}