using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.validadores
{
    public class EventoDeportivoValidador
    {
        private readonly IPersonaRepositorio _repoPersona;

        public EventoDeportivoValidador(IPersonaRepositorio repositorioPersona)
        {
            _repoPersona = repositorioPersona;
        }

        public bool Validar(EventoDeportivo evento, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(evento.Nombre))
            {
                mensajeError = "ERROR - Nombre obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(evento.Descripcion))
            {
                mensajeError = "ERROR - Descripcion obligatoria.";
                return false;
            }

            if (evento.FechaHoraInicio <= DateTime.Now)
            {
                mensajeError = "ERROR - La fecha debe ser mayor a la actual.";
                return false;
            }

            if (evento.CupoMaximo <= 0)
            {
                mensajeError = "ERROR - El cupo debe ser mayor a 0.";
                return false;
            }

            if (evento.DuracionHoras <= 0)
            {
                mensajeError = "ERROR - La duracion del evento debe ser mayor a 0.";
                return false;
            }

            if (!_repoPersona.ExistsById(evento.ResponsableId))
            {
                mensajeError = "ERROR - El Responsable no es valido.";
                return false;
            }

            return true;
        }
    }
}
