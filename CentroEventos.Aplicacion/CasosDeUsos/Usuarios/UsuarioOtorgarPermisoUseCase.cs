using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion
{
    public class UsuarioOtorgarPermisoUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public void Ejecutar(int idUsuario, List<EnumPermiso> permisosNuevos, int idUsuarioSolicitante)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuarioSolicitante, EnumPermiso.UsuarioOtorgarPermiso))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            var usuario = _repositorioUsuario.BuscarPorId(idUsuario) ?? throw new EntidadNotFoundException("ERROR - El usuario no existe.");

            _repositorioUsuario.OtorgarPermiso(usuario, permisosNuevos);
        }
    }
}
