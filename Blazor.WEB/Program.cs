using Blazor.WEB;
using Blazor.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*Si el proyecto se conectara a Azure le colocaríamos la liga que nos proporcione Azure
  o la liga de cualquier otro Hosting del cual estemos consumiendo el servicio API.*/
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7261/") });


/*3 Formas de inyectar servicios por NET Core 
 -AddScoped Cuando necesesita crear una nueva instancias, genera objetos separados muy recomendable
 -AddTransient Paara inyectar solo una vex, empleado como alimentador de BD
 -AddSingleton Crea instancia de objeto y la reutiliza, muy vulnerable en seguridad(DataSensitive) y consume muhca memoria
*/
builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();
