using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.validadores;

namespace CentroEventos.Aplicacion.CasosDeUsos.Evento
{
    public class EventoDeportivoAltaUseCase(IEventoDeportivoRepositorio repoEvento, IServicioAutorizacion servicioAutorizacion,EventoDeportivoValidador validador){
            private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly EventoDeportivoValidador _validadorEvento =  validador;

            public void Ejecutar(EventoDeportivo evento, int idUsuario){

                if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.EventoAlta)){
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }

                if (!_validadorEvento.Validar(evento, out string mensajeError))
                {
                    throw new ValidacionException(mensajeError);
                }

                _repositorioEvento.Agregar(evento);
            
            }
    }
}
