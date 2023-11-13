using Microsoft.EntityFrameworkCore;
using Repositorio.DBContext;

//Ijnectando todas as referencias
using Repositorio.Contrato;
using Repositorio.ImplenetacaoRepositorio;
using Repositorio.Contrato.Generica;
using Repositorio.ImplenetacaoRepositorio.Generico;

using Utilidades;

using Servico.Contrato;
using Servico.ImplementacaoServico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSQl"));
});

//Repositorios
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

//Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Serviços
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<ICategoriaServico, CategoriaServico>();
builder.Services.AddScoped<IProductoServico, ProductoServico>();
builder.Services.AddScoped<IVentaServico, VentaServico>();
builder.Services.AddScoped<IDashdoardServico, DashdoardServico>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
