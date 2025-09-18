namespace Infrastructure.Models;

public class ProductCreateRequest
{
    public required string ProductName { get; set; }

    public decimal ProductPrice { get; set; }
}