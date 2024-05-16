using Blazored.Toast;
using MextFullStack.WasmClient;
using MextFullStack.WasmClient.Helpers;
using MextFullStack.WasmClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAI.Extensions;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7010/api/") });

builder.Services.AddSingleton<UrlHelper>(new UrlHelper("https://localhost:7010/api/"));

builder.Services.AddBlazoredToast();

builder.Services.AddToaster(config =>
{
    //example customizations
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});

builder.Services.AddScoped<IToasterService, SotseraToasterManager>();

const string apiKey = "sk-pro";

builder.Services.AddOpenAIService(settings => settings.ApiKey = apiKey);

await builder.Build().RunAsync();
