using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class ServicioLogin
    {
        public Usuario? UsuarioLog { get; set; } = null!;

        public bool EstaLogeado { get; set; } = false;

        public void SetUser(Usuario user)
        {
            UsuarioLog = user;
        }

        public Usuario GetUser()
        {
            return UsuarioLog!;
        }

        public void Logueado()
        {
            EstaLogeado = true;
        }

        public bool UsuarioEstaLogeado() => UsuarioLog != null;

        public void CerrarSesion()
        {
            UsuarioLog = null;
            EstaLogeado = false;
        }

        public int GetId()
        {
            if (UsuarioLog != null)
            {
                return UsuarioLog.Id;
            }

            return 0;
        }

    }
}
