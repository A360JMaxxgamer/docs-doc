using System;
using System.Net.Http;
using DocsDoc.Webapp;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

builder.Services.AddMudServices();

var currentAssembly = typeof(App).Assembly;
builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));

builder.Services.AddSingleton(new MinioClient("https://localhost:9001", "minio", "minioKey123").WithSSL());

await builder.Build().RunAsync();