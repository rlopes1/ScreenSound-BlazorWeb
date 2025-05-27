using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ScreenSound.Web;
using ScreenSound.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ArtistaAPI>();

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();

//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using ScreenSound.Web;
//using ScreenSound.Web.Services;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddTransient<ArtistaAPI>();

//var apiUrl = builder.Configuration["APIServer:Url"];
//if (string.IsNullOrEmpty(apiUrl))
//    throw new InvalidOperationException("API URL não está configurada.");

//builder.Services.AddHttpClient("API", client =>
//{
//    client.BaseAddress = new Uri(apiUrl);
//    client.DefaultRequestHeaders.Add("Accept", "application/json");
//});

//await builder.Build().RunAsync();