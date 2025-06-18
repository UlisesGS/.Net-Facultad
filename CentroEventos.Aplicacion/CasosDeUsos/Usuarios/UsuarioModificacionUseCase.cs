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


            if (!string.IsNullOrWhiteSpace(usuario.HashPassword))
            {

                usuarioAux.HashPassword = Hasheador.Hashear(usuario.HashPassword);
            }

            if (!string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                usuarioAux.Nombre = usuario.Nombre;
            }

            if (!string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                usuarioAux.Apellido = usuario.Apellido;
            }

            if (!string.IsNullOrWhiteSpace(usuario.Email))
            {
                usuarioAux.Email = usuario.Email;
            }

            _repositorioUsuario.Modificar(usuarioAux);
        }
    }
}
