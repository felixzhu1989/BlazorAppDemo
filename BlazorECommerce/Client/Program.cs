global using BlazorECommerce.Shared;
global using System.Net.Http.Json;

using BlazorECommerce.Client;
using BlazorECommerce.Client.Services.CartServices;
using BlazorECommerce.Client.Services.CategoryServices;
using BlazorECommerce.Client.Services.ProductServices;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService,CartService>();

await builder.Build().RunAsync();
