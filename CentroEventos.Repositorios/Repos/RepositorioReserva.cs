using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.Data;


namespace CentroEventos.Repositorios.repos
{
    public class RepositorioReserva(DataContext db) : IReservaRepositorio
    {
        public void Agregar(Reserva reserva)
        {
            db.Reservas.Add(reserva);
            db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Reserva? reserva = BuscarPorId(id);
            db.Reservas.Remove(reserva!);
            db.SaveChanges();
        }

        public Reserva? BuscarPorId(int id)
        {
            return db.Reservas.FirstOrDefault(r => r.Id == id);
        }
        public bool ExistsById(int id)
        {
            return db.Reservas.Any(r => r.Id == id);
        }

        public bool ExistsByIdEvento(int idEvento)
        {
            return db.Reservas.Any(r => r.EventoDeportivoId == idEvento);
        }

        public bool ExistsByIdPersona(int idPersona)
        {
            return db.Reservas.Any(r => r.PersonaId == idPersona);
        }

        public bool ExistsDuplicatePersona(int idPersona, int idEventoDeportivo)
        {
            return db.Reservas.Any(r => r.EventoDeportivoId == idEventoDeportivo && r.PersonaId == idPersona);
        }

        public List<Reserva> Listar()
        {
            return db.Reservas.ToList();
        }

        public List<Reserva> ListarPorEvento(int idEvento)
        {
            return db.Reservas.Where(r => r.EventoDeportivoId == idEvento).ToList();
        }

        public void Modificar(Reserva reserva)
        {
            var original = db.Reservas.Find(reserva.Id);

            if (original != null)
            {
                original.PersonaId = reserva.PersonaId;
                original.EventoDeportivoId = reserva.EventoDeportivoId;
                original.FechaAltaReserva = reserva.FechaAltaReserva;
                original.EstadoAsistencia = reserva.EstadoAsistencia;

                db.SaveChanges();
            }
        }

        public int QuantityCupo(int idEventoDeportivo)
        {
            return db.Reservas.Where(r => r.EventoDeportivoId == idEventoDeportivo).ToList().Count;
        }
    }
}