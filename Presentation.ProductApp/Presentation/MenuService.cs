using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Presentation.ProductApp.Presentation;

public class MenuService(IProductService productService, IFileService fileService)
{
    private readonly IProductService _productService = productService;
    private readonly IFileService _fileService = fileService;

    private readonly JsonSerializerOptions _json = new JsonSerializerOptions()
    {
        WriteIndented = true,

    };


    public void OpenMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---- MAIN MENU ----");
            Console.WriteLine("\n 1. Add New Product ");
            Console.WriteLine("\n 2. Show All Products ");
            Console.WriteLine("\n 3.Get Products From File ");
            Console.WriteLine("\n 4. Save Products To File ");
            Console.WriteLine("\n Q. Quit...");

            Console.Write("\nChoose Option: ");

            var menuOption = Console.ReadLine().ToUpperInvariant();

            switch (menuOption)
            {
                case "1":
                    Console.Clear();
                    AddProductOption();
                    break;

                case "2":
                    Console.Clear();

                    ShowAllProdcuts();
                    break;

                case "3":
                    Console.Clear();

                    ImportProductsFromFile();
                    break;

                case "4":
                    Console.Clear();

                    SaveToFile();
                    break;

                case "Q":

                    break;
            }
        }
    }

    private void AddProductOption()
    {
        Console.Clear();
        Console.Write("Name: ");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
            Console.WriteLine("Error: Must Enter Name");

        Console.Write("Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out var price))
            Console.WriteLine("Error: Price Not Valid");

        var success = _productService.AddProduct(new ProductCreateRequest
        {
            ProductName = name!.Trim(),
            ProductPrice = price,

        });

    }

    private void ShowAllProdcuts()
    {
        var allProducts = _productService.GetProducts().ToList();
        if (allProducts.Count == 0)
            Console.WriteLine("No Products Found");

        foreach (var product in allProducts)
        {
            Console.WriteLine($"{product.ProductName} {product.ProductPrice} {product.Id}");
            Console.ReadKey();
        }

    }

    private void ImportProductsFromFile()
    {
        var content = _fileService.GetContentFromFile();
        if (string.IsNullOrEmpty(content))
        {
            Console.WriteLine("File Not Found");
            return;
        }
        var imported = JsonSerializer.Deserialize<List<Product>>(content, _json);

        try
        {

            if (imported.Count == 0)
            {
                Console.WriteLine("No products found in file");
            }
        }
        catch
        {
            Console.WriteLine("Invalid Json Format:");

        }

        foreach (var product in imported)
        {
            var ok = _productService.AddProduct(new ProductCreateRequest
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            });
        }

        Console.WriteLine($"Imported Products");
       

    }

    private void SaveToFile()
    {
        var list = _productService.GetProducts().ToList();
        var json = JsonSerializer.Serialize(list, _json);
        var ok = _fileService.SaveToFile(json);

        Console.WriteLine(ok ? $"Saved {list.Count}" : "Save Failed");
        Console.ReadKey();
        
    }
}
