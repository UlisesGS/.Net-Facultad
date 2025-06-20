using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioBuscarUseCase(IUsuarioRepositorio repoUsuario)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        public Usuario Ejecutar(string email)
        {
            return _repositorioUsuario.ObtenerPorEmail(email) ?? throw new EntidadNotFoundException("ERROR - Usuario no encontrado.");
        }
    }
}