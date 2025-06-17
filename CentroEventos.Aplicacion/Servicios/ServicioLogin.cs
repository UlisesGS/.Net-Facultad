using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion
{
    public class ServicioLogin
    {
        public Usuario usuario { get; set; } = null!;

        public bool EstaLogeado { get; set; } = false;

        public void SetUser(Usuario user)
        {
            usuario = user;
        }

        public Usuario GetUser()
        {
            if (usuario == null)
            {
                throw new EntidadNotFoundException("ERROR - No se pudo obtener el usuario.");
            }

            return usuario;
        }

        public void Logueado()
        {
            EstaLogeado = true;
        }

    }
}
