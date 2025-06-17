using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioLoginUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public Usuario Ejecutar(string email, string password)
        {
            var usuario = _repositorioUsuario.ObtenerPorEmail(email);

            if (usuario == null)
            {
                throw new EntidadNotFoundException("ERROR - Usuario no encontrado.");
            }

            if (usuario.HashPassword != Hasheador.Hashear(password))
            {
                throw new FalloAutorizacionException("ERROR - Contraseña incorrecta.");
            }

            return usuario;
        }
        
    }
}
