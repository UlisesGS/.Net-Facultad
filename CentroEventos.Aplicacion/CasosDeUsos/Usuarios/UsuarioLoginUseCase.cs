using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioLoginUseCase(IUsuarioRepositorio repoUsuario)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        public bool Ejecutar(string email, string password)
        {
            if (_repositorioUsuario.ConseguirDatos(email, password, out string mensajeError))
            {
                return true;
            }
            throw new ValidacionException(mensajeError);
        }
    }
}
