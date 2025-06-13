using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores
{
    public class PersonaValidador
    {
        private readonly IPersonaRepositorio _repoPersona;

        public PersonaValidador(IPersonaRepositorio repositorioPersona)
        {
            _repoPersona = repositorioPersona;
        }

        public bool Validar(Persona persona, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                mensajeError = "ERROR - Nombre obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(persona.Apellido))
            {
                mensajeError = "ERROR - Apellido obligatorio.";
                return false;
            }

            if (persona.DNI == null)
            {
                mensajeError = "ERROR - DNI obligatorio.";
                return false;
            }

            if (persona.DNI.Value.ToString().Length != 8)
            {
                mensajeError = "ERROR - La longitud del DNI debe ser de 8.";
                return false;
            }

            if (_repoPersona.ExistsByDNI(persona.DNI.Value))
            {
                mensajeError = "ERROR - DNI ya registrado.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(persona.Email))
            {
                mensajeError = "ERROR - Email obligatorio.";
                return false;
            }

            if (_repoPersona.ExistsByEmail(persona.Email))
            {
                mensajeError = "ERROR - Email ya registrado.";
                return false;
            }

            return true;
        }
    }
}