using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

string filePath = @"c:\data\products.json";
var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileService>(_ => new JsonFileService(filePath, new JsonSerializerOptions { WriteIndented = true }));
builder.Services.AddSingleton<IProductService>(_ => new ProductService());


var app = builder.Build();