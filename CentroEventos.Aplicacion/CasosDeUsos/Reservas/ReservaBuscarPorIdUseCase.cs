using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class ReservaBuscarPorIdUseCase(IReservaRepositorio repoReserva)
    {
        private readonly IReservaRepositorio _repositorioReserva = repoReserva;

        public Reserva? Ejecutar(int id)
        {
            return _repositorioReserva.BuscarPorId(id) ?? throw new EntidadNotFoundException("ERROR - Reserva no encontrada.");
        }
    }
}
