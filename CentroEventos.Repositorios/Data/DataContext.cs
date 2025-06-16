using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        //nullable disable
        public DbSet<Persona> Personas { get; set; }
        public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("data source=database.sqlite");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
    }
}