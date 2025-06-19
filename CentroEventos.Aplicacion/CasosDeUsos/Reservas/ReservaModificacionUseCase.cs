using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Reservas
{
    public class ReservaModificacionUseCase(IReservaRepositorio repoReserva, IServicioAutorizacion servicioAutorizacion, IPersonaRepositorio repoPersona, IEventoDeportivoRepositorio repoEvento){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;
            private readonly IEventoDeportivoRepositorio _repositorioEventoDeportivo = repoEvento;
        
        public void Ejecutar(Reserva reserva, int idUsuario){

            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaModificacion))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            var personaAux = _repositorioPersona.BuscarPorId(reserva.PersonaId) ?? throw new EntidadNotFoundException("ERROR - La persona no existe.");
            
            if (_repositorioEventoDeportivo.ExistsByIdResponsableEnEvento(reserva.PersonaId, reserva.EventoDeportivoId))
            {
                throw new ValidacionException("ERROR - El responsable no puede inscribirse al evento.");
            }

            if (_repositorioReserva.ExistsByIdPersona(reserva.PersonaId) && reserva.PersonaId != personaAux.Id)
            {
                throw new DuplicadoException("ERROR - La Persona ya esta registrada.");
            }

            if (!_repositorioReserva.ExistsDuplicatePersona(reserva.PersonaId, reserva.EventoDeportivoId))
            {
                if (_repositorioReserva.QuantityCupo(reserva.EventoDeportivoId) >= _repositorioEventoDeportivo.CupoMaximo(reserva.EventoDeportivoId))
                {
                    throw new CupoExcedidoException("ERROR - No hay Cupo disponible.");
                }
            }
            
            _repositorioReserva.Modificar(reserva);
        }
    }
}
