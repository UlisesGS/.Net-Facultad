using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUsos.Personas
{
    public class PersonaAltaUseCase(IPersonaRepositorio repoPersona, IServicioAutorizacion servicioAutorizacion,PersonaValidador validador){
            private readonly IPersonaRepositorio _repositorioPersona = repoPersona;
            private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
            private readonly PersonaValidador _validadorPersona =  validador;

            public void Ejecutar(Persona persona, int idUsuario){

                if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioAlta))
                {
                    throw new FalloAutorizacionException("ERROR - No estas autorizado.");
                }
            
                if (!_validadorPersona.Validar(persona, out string mensajeError))
                {
                    throw new ValidacionException(mensajeError);
                }

                _repositorioPersona.Agregar(persona);
            
            }
    }
}
