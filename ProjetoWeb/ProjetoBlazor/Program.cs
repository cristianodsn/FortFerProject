using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjetoBlazor;
using ProjetoBlazor.Services;
using System.ComponentModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IProdutoService, ProdutoService>();
var baseUrl = "https://localhost:7153";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl)});
await builder.Build().RunAsync();
