using Microsoft.EntityFrameworkCore;
using CentroEventos.UI;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios.Data;
using CentroEventos.Repositorios;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar el context de base de datos
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlite("Data Source=database.sqlite"));

//Inyeccion de dependencias Services
//

var app = builder.Build();

//inicializar base de datos
DbSqlite.Inicializar();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
