using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioModificacionUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;

        public void Ejecutar(Usuario usuario, int idUsuario)
        {
            if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioModificacion))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            var usuarioAux = _repositorioUsuario.BuscarPorId(usuario.Id) ?? throw new EntidadNotFoundException("ERROR - El usuario no existe.");

            if (string.IsNullOrWhiteSpace(usuario.Password))
            {
                throw new ValidacionException("ERROR - Contraseña obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ValidacionException("ERROR - Nombre obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                throw new ValidacionException("ERROR - Apellido Obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                throw new ValidacionException("ERROR - Email obligatorio.");
            }

            _repositorioUsuario.Modificar(usuario);
        }
    }
}
