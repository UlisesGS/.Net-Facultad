using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Repositorios.Data;

namespace CentroEventos.Repositorios
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

        public void Eliminar(Usuario usuario)
        {
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
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

        public void OtorgarPermiso(Usuario usuario, EnumPermiso permiso)
        {
            usuario.Permisos.Add(permiso);
            db.Usuarios.Update(usuario);
            db.SaveChanges();
        }
    }
}
