namespace CentroEventos.Aplicacion;

public class UsuarioValidador
{
    private readonly IUsuarioRepositorio _repoUsuario;

    public UsuarioValidador(IUsuarioRepositorio repositorioUsuario)
    {
        _repoUsuario = repositorioUsuario;
    }
        public bool Validar(Usuario usuario, out string mensajeError)
        {

            mensajeError = string.Empty;
            if (string.IsNullOrWhiteSpace(usuario.HashPassword))
            {
                mensajeError = " ERROR - Contraseña obligatoria.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                mensajeError = "ERROR - Nombre obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                mensajeError = "ERROR - Apellido obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
            {
                mensajeError = "ERROR - Email obligatorio.";
                return false;
            }

            if (_repoUsuario.ExistsByEmail(usuario.Email))
            {
                mensajeError = "ERROR - Email ya registrado.";
                return false;   
            }

            return true;
        }
}
