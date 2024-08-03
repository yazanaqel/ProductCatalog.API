using Blazored.LocalStorage;
using BlazorUI;
using BlazorUI.Services.Category;
using BlazorUI.Services.Product;
using BlazorUI.Services.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44352") });

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddOptions();


builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
