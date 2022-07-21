using BlazorStore.Client.Web;
using BlazorStore.Client.Shared.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddSingleton<CartStateContainer>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7278") });

await builder.Build().RunAsync();
