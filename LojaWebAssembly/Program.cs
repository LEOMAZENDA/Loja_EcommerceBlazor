using LojaWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//Usings adicionados
using Blazored.LocalStorage;
using Blazored.Toast;
using LojaWebAssembly.Servicos.Contrato;
using LojaWebAssembly.Servicos.Implementacao;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//Serviços adicionados
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5294/api") });//Url da API

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoServico, ProductoServico>();
builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<IVentaServico, VentaServico>();
builder.Services.AddScoped<IDashboardServico, DashboardServico>();


await builder.Build().RunAsync();
