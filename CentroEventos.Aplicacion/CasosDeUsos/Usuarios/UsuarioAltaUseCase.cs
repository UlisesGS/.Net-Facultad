using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion
{
    public class UsuarioAltaUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion, UsuarioValidador validador)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        private readonly UsuarioValidador _validadorUsuario = validador;
        public void Ejecutar(Usuario usuario, int idUsuario)
        {

            if (!_validadorUsuario.Validar(usuario, out string mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }


            if (!_repositorioUsuario.HayUsuarios())
            {
                usuario.Permisos = Enum.GetValues<EnumPermiso>().ToList();
            }
            else
            {

                if (!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioAlta))
                {
                    throw new FalloAutorizacionException("ERROR - No estás autorizado.");
                }
            }

            usuario.HashPassword = Hasheador.Hashear(usuario.Password!);

            usuario.Password = null;

            _repositorioUsuario.Agregar(usuario);
        }

    }
}