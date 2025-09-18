using Infrastructure.Models;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _productList = [];

    public bool AddProduct(ProductCreateRequest newProduct)
    {
        if (newProduct == null)
            return false;

        if (string.IsNullOrWhiteSpace(newProduct.ProductName))
            return false;

        Product product = new()
        {
            ProductName = newProduct.ProductName,
            ProductPrice = newProduct.ProductPrice,
        };

        _productList.Add(product);
        return true;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _productList;
    }
}
