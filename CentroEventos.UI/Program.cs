using Microsoft.EntityFrameworkCore;
using CentroEventos.UI;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios.Data;
using CentroEventos.Repositorios.repos;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUsos.Personas;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.CasosDeUsos.Evento;
using CentroEventos.Aplicacion.validadores;
using CentroEventos.Aplicacion.CasosDeUsos.Reservas;

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
builder.Services.AddScoped<IEventoDeportivoRepositorio, RepositorioEvento>();
builder.Services.AddScoped<EventoDeportivoValidador>();
builder.Services.AddScoped<IReservaRepositorio, RepositorioReserva>();
builder.Services.AddScoped<ReservaValidador>();
// Usuarios
builder.Services.AddScoped<UsuarioBajaUseCase>();
builder.Services.AddScoped<UsuarioAltaUseCase>();
builder.Services.AddScoped<UsuarioLoginUseCase>();
builder.Services.AddScoped<UsuarioBuscarUseCase>();
builder.Services.AddScoped<UsuarioListarUseCase>();
builder.Services.AddScoped<UsuarioBuscarIdUseCase>();
builder.Services.AddScoped<UsuarioModificacionUseCase>();
builder.Services.AddScoped<UsuarioOtorgarPermisoUseCase>();


// Personas
builder.Services.AddScoped<PersonaBajaUseCase>();
builder.Services.AddScoped<PersonaAltaUseCase>();
builder.Services.AddScoped<PersonaListarUseCase>();
builder.Services.AddScoped<PersonaBuscarPorIdUseCase>();
builder.Services.AddScoped<PersonaModificacionUseCase>();

// Eventos
builder.Services.AddScoped<EventoDeportivoBajaUseCase>();
builder.Services.AddScoped<EventoDeportivoAltaUseCase>();
builder.Services.AddScoped<EventoDeportivoListarUseCase>();
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();
builder.Services.AddScoped<EventoDeportivoBuscarPorIdUseCase>();
builder.Services.AddScoped<EventoDeportivoModificacionUseCase>();



// Reservas
builder.Services.AddScoped<ReservaBajaUseCase>();
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ReservaListarUseCase>();
builder.Services.AddScoped<ReservaBuscarPorIdUseCase>();
builder.Services.AddScoped<ReservaModificacionUseCase>();

var app = builder.Build();

//inicializar base de datos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    DbSqlite.Inicializar(context);
}


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