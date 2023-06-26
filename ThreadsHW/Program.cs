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
        ProductCard[] cards = {
            new() { Product = new Product { Name = "Apple", Price = 0.5m }, Quantity = 3 },
            new() { Product = new Product { Name = "Banana", Price = 0.3m }, Quantity = 2 },
            new() { Product = new Product { Name = "Orange", Price = 0.4m }, Quantity = 4 },
            new() { Product = new Product { Name = "Grapes", Price = 0.6m }, Quantity = 1 }
        };

        var quantityDiscountStrategy = new QuantityDiscountStrategy();
        var amountDiscountStrategy = new AmountDiscountStrategy();

        cards[0].DiscountStrategy = quantityDiscountStrategy;
        cards[1].DiscountStrategy = quantityDiscountStrategy;
        cards[2].DiscountStrategy = amountDiscountStrategy;
        cards[3].DiscountStrategy = amountDiscountStrategy;

        foreach (var card in cards)
        {
            decimal discount = card.CalculateDiscount();
            Console.WriteLine($"Discount for {card.Product.Name}: {discount}");
        }

        Console.ReadLine();
    }
}
