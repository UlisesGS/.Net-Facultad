using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.validadores
{
    public class ReservaValidador
    {
        private readonly IPersonaRepositorio _repoPersona;
        private readonly IEventoDeportivoRepositorio _repoEventoDeportivo;
        private readonly IReservaRepositorio _repoReserva;

        public ReservaValidador(
            IPersonaRepositorio repositorioPersona,
            IEventoDeportivoRepositorio repositorioEventoDeportivo,
            IReservaRepositorio repositorioReserva)
        {
            _repoPersona = repositorioPersona;
            _repoEventoDeportivo = repositorioEventoDeportivo;
            _repoReserva = repositorioReserva;
        }

        public bool Validar(Reserva reserva, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (!_repoPersona.ExistsById(reserva.PersonaId))
            {
                mensajeError = "ERROR - La Persona no es valida.";
                return false;
            }

            if (!_repoEventoDeportivo.ExistsById(reserva.EventoDeportivoId))
            {
                mensajeError = "ERROR - El Evento Deportivo no es valido.";
                return false;
            }

            if (_repoReserva.ExistsDuplicatePersona(reserva.PersonaId, reserva.EventoDeportivoId))
            {
                mensajeError = "ERROR - La Reserva ya esta registrada.";
                return false;
            }

            if (_repoReserva.QuantityCupo(reserva.EventoDeportivoId) == _repoEventoDeportivo.CupoMaximo(reserva.EventoDeportivoId))
            {
                mensajeError = "ERROR - No hay cupo disponible.";
                return false;
            }

            return true;
        }
    }
}
