using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion
{
    public class UsuarioBajaUseCase
    {
        private readonly IUsuarioRepositorio _repositorioUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion;

        public UsuarioBajaUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
        {
            _repositorioUsuario = repoUsuario;
            _servicioAutorizacion = servicioAutorizacion;
        }

        public void Ejecutar(int idUsuarioAEliminar, int idUsuarioSolicitante)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuarioSolicitante, EnumPermiso.UsuarioBaja))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            if (!_repositorioUsuario.ExistsById(idUsuarioAEliminar))
            {
                throw new ValidacionException("ERROR - Este usuario no existe.");
            }

            _repositorioUsuario.Eliminar(idUsuarioAEliminar);
        }
    }
}
