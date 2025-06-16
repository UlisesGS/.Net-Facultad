using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion;

public interface IUsuarioRepositorio
{
    public Boolean ExistsByEmail(string email);

    public Usuario Agregar(Usuario usuario);

    public void Eliminar(Usuario usuario);

    public void Modificar(Usuario usuario);

    public Usuario? BuscarPorId(int id);

    public List<Usuario> Listar();

    public void OtorgarPermiso(Usuario usuario, EnumPermiso permiso);

    public bool HayUsuarios();

    public Usuario? ObtenerPorEmail(string email);
}
