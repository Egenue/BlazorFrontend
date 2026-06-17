using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorFrontend;
using BlazorFrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["BaseApiUrl"] ?? "http://localhost:3000/";

builder.Services.AddScoped(sp => new HttpClient
{ 
    BaseAddress = new Uri(apiUrl) 
});

builder.Services.AddScoped<ApiClient>();
builder.Services.AddSingleton<AppState>();

await builder.Build().RunAsync();
