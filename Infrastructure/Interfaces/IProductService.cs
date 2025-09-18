
using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductService
{
    public bool AddProduct(ProductCreateRequest newProduct);

    IEnumerable<Product> GetProducts();
}
