using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioBuscarIdUseCase(IUsuarioRepositorio repoUsuario)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        public Usuario Ejecutar(int id)
        {
            return _repositorioUsuario.BuscarPorId(id) ?? throw new EntidadNotFoundException("ERROR - Usuario no encontrado.");
        }
    }
}