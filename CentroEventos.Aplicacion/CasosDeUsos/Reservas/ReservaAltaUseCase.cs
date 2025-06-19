using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.validadores;

namespace CentroEventos.Aplicacion.CasosDeUsos.Reservas
{
    public class  ReservaAltaUseCase(IReservaRepositorio repoReserva, IServicioAutorizacion servicioAutorizacion,ReservaValidador validador, IEventoDeportivoRepositorio repoEvento){
            private readonly IReservaRepositorio _repositorioReserva = repoReserva;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly ReservaValidador _validadorReserva =  validador;

            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;

            public void Ejecutar(Reserva reserva, int idUsuario)
        {

            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.ReservaAlta))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            if (_repositorioEvento.ExistsByIdResponsableEnEvento(reserva.PersonaId, reserva.EventoDeportivoId))
            {
                throw new ValidacionException("ERROR - El responsable no puede inscribirse al evento.");
            }

            if (!_validadorReserva.Validar(reserva, out string mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }

            reserva.EstadoAsistencia = EnumEstadoAsistencia.pendiente;
            reserva.FechaAltaReserva = DateTime.Now;
            _repositorioReserva.Agregar(reserva);
        }

    }
}
