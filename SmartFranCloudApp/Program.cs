using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SmartFranCloudApp;
using SmartFranCloudApp.Themes; 
using SmartFranCloudApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Registrar servicios de MudBlazor
builder.Services.AddMudServices();

// Singleton para compartir estado entre VentaMinorista y modal de pago
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<ToastService>();

await builder.Build().RunAsync();
