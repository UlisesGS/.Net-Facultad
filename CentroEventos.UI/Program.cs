using Microsoft.EntityFrameworkCore;
using CentroEventos.UI;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios.Data;
using CentroEventos.Repositorios.repos;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUsos.Personas;
using CentroEventos.Aplicacion.Validadores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar el context de base de datos
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlite("Data Source=database.sqlite"));

//Inyeccion de dependencias Services
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioAutorizacion>();
builder.Services.AddScoped<ServicioLogin>();

builder.Services.AddScoped<IPersonaRepositorio, RepositorioPersona>();
builder.Services.AddScoped<PersonaValidador>();

// Usuarios
builder.Services.AddScoped<UsuarioAltaUseCase>();
builder.Services.AddScoped<UsuarioLoginUseCase>();
builder.Services.AddScoped<UsuarioBuscarUseCase>();
builder.Services.AddScoped<UsuarioListarUseCase>();

// Personas
builder.Services.AddScoped<PersonaAltaUseCase>();
builder.Services.AddScoped<PersonaListarUseCase>();

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