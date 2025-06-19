using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.validadores;

namespace CentroEventos.Aplicacion.CasosDeUsos.Evento
{
    public class EventoDeportivoModificacionUseCase(IEventoDeportivoRepositorio repoEvento, EventoDeportivoValidador validador, IServicioAutorizacion servicioAutorizacion){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly EventoDeportivoValidador _validador = validador;
            public void Ejecutar(EventoDeportivo evento, int idUsuario){

                if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.EventoModificacion))
                {
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }
                
                var eventoAux = _repositorioEvento.BuscarPorId(evento.Id) ?? throw new EntidadNotFoundException("ERROR - El evento no existe.");
            
                if (eventoAux.FechaHoraInicio < DateTime.Now)
                {
                    throw new OperacionInvalidaException("ERROR - La fecha expiro.");
                }

                if(!_validador.Validar(evento, out string mensajeError))
                {
                    throw new OperacionInvalidaException(mensajeError);
                }

                _repositorioEvento.Modificar(evento);
            }
    }
}