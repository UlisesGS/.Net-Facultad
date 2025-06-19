using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Evento
{
    public class EventoDeportivoBuscarPorIdUseCase(IEventoDeportivoRepositorio repoEvento)
    {
        private readonly IEventoDeportivoRepositorio _repositorioEvento = repoEvento;

        public EventoDeportivo Ejecutar(int id)
        {
            return _repositorioEvento.BuscarPorId(id) ?? throw new EntidadNotFoundException("ERROR - Evento no encontrado.");
        }
    }
}
