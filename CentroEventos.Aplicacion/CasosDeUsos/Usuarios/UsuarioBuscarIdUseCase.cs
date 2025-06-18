using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioBuscarIdUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        public Usuario Ejecutar(int id)
        {
            return _repositorioUsuario.BuscarPorId(id) ?? throw new EntidadNotFoundException("ERROR - Usuario no encontrado.");
        }
    }
}