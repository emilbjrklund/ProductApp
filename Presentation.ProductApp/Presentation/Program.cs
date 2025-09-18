using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ProductApp.Presentation;
using System.Text.Json;

string filePath = @"c:\data\products.json";
var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileService>(_ => new JsonFileService(filePath, new JsonSerializerOptions { WriteIndented = true }));
builder.Services.AddSingleton<IProductService>(_ => new ProductService());
builder.Services.AddSingleton<MenuService>();

var app = builder.Build();

var menu = app.Services.GetRequiredService<MenuService>();
menu.OpenMainMenu();


builder.Build();