using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Arnkels.OpenNexus.WebUI;
using Arnkels.OpenNexus.WebUI.HttpRepositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7194/") });

builder.Services.AddScoped<ICompanyStatusHttpRepository, CompanyStatusHttpRepository>();

await builder.Build().RunAsync();