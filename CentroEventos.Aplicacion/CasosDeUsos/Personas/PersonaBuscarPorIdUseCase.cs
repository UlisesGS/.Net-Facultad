using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUsos.Personas
{
    public class PersonaBuscarPorIdUseCase(IPersonaRepositorio repoPersona)
    {
        private readonly IPersonaRepositorio _repositorioPersona = repoPersona;

        public Persona? Ejecutar(int id)
        {
            return _repositorioPersona.BuscarPorId(id) ?? throw new EntidadNotFoundException("ERROR - Persona no encontrada.");
        }
    }
}
