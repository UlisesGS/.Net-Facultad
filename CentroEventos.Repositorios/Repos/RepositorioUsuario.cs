using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios.repos
{
    public class RepositorioUsuario(DataContext db) : IUsuarioRepositorio
    {

        public Usuario Agregar(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return usuario;
        }

        public Usuario? BuscarPorId(int id)
        {
            return db.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Eliminar(int id)
        {
            Usuario? us = BuscarPorId(id);
            db.Usuarios.Remove(us!);
            db.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            return db.Usuarios.Any(u => u.Id == id);
        }
        public bool ExistsByEmail(string email)
        {
            return db.Usuarios.Any(u => u.Email == email);
        }

        public bool HayUsuarios()
        {
            return db.Usuarios.Any();
        }

        public List<Usuario> Listar()
        {
            return db.Usuarios.ToList();
        }

        public void Modificar(Usuario usuario)
        {
            db.Usuarios.Update(usuario);
            db.SaveChanges();
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return db.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void OtorgarPermiso(Usuario usuario, List<EnumPermiso> permisosNuevos)
        {
            usuario.Permisos = permisosNuevos;
            db.Usuarios.Update(usuario);
            db.SaveChanges();
        }
        
        public bool ConseguirDatos(string email, string password, out string mensajeError)
        {
            mensajeError = string.Empty;

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario != null)
            {
                string? aux = usuario.HashPassword;
                string hash = Hasheador.Hashear(password);
                if (aux == hash)
                {
                    return true;
                }
                mensajeError = "ERROR - Contraseña incorrecta.";
                return false;
            }
            else
            {
                mensajeError = "ERROR - El usuario no existe.";
            }
            return false;
        }
    }
}
