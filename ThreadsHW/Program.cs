using Newtonsoft.Json;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal totalPrice);
}

public class QuantityDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalPrice)
    {
        
        return totalPrice * 0.1m; 
    }
}

public class AmountDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalPrice)
    {
        
        return totalPrice * 0.05m; 
    }
}

public class ProductCard
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public IDiscountStrategy DiscountStrategy { get; set; }

    public decimal CalculateDiscount()
    {
        decimal totalPrice = Product.Price * Quantity;
        return DiscountStrategy.CalculateDiscount(totalPrice);
    }
}

class Program
{
    static void Main()
    {
        var product = new Product
        {
            Name = "Apple",
            Price = 0.5m
        };


        string json1 = JsonConvert.SerializeObject(product);


        Console.WriteLine(json1);
        
        
        
        string json2 = "{\"Name\":\"Apple\",\"Price\":0.5}";


        Product product2 = JsonConvert.DeserializeObject<Product>(json2);


        Console.WriteLine($"Product Name: {product2.Name}");
        Console.WriteLine($"Product Price: {product2.Price}");
    }
}
