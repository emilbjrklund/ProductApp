namespace Infrastructure.Models;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string ProductName { get; set; } = string.Empty;

    public decimal ProductPrice { get; set; }
}
