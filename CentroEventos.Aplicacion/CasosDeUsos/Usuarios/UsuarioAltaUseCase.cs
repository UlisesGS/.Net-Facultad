using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion
{
    public class UsuarioAltaUseCase(IUsuarioRepositorio repoUsuario, UsuarioValidador validador)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly UsuarioValidador _validadorUsuario = validador;
        public void Ejecutar(Usuario usuario)
        {

            if (!_validadorUsuario.Validar(usuario, out string mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }

            if (!_repositorioUsuario.HayUsuarios())
            {
                usuario.Permisos = Enum.GetValues<EnumPermiso>().ToList();
            }
    
            usuario.HashPassword = Hasheador.Hashear(usuario.HashPassword!);

            _repositorioUsuario.Agregar(usuario);
        }

    }
}