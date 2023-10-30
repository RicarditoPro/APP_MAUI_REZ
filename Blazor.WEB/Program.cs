using Blazor.WEB;
using Blazor.WEB.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*Si el proyecto se conectara a Azure le colocaríamos la liga que nos proporcione Azure
  o la liga de cualquier otro Hosting del cual estemos consumiendo el servicio API.*/
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7188p/") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7261/") });
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
