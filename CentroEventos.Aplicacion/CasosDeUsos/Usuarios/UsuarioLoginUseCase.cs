using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioLoginUseCase(IUsuarioRepositorio repoUsuario)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        public bool Ejecutar(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ValidacionException("ERROR - Email obligatorio.");
            }
            
            
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ValidacionException("ERROR - Contraseña obligatoria.");
            }
            if (_repositorioUsuario.ConseguirDatos(email, password, out string mensajeError))
            {
                return true;
            }

            throw new ValidacionException(mensajeError);
        }
    }
}
