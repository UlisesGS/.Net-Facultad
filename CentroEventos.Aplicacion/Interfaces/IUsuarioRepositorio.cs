using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion;

public interface IUsuarioRepositorio
{
    public Boolean ExistsByEmail(string email);

    public Usuario Agregar(Usuario usuario);

    public void Eliminar(int id);

    public bool ExistsById(int id);
    public void Modificar(Usuario usuario);

    public Usuario? BuscarPorId(int id);

    public List<Usuario> Listar();

    public void OtorgarPermiso(Usuario usuario, List<EnumPermiso> permisosNuevos);

    public bool HayUsuarios();

    public Usuario? ObtenerPorEmail(string email);

    public bool ConseguirDatos(string email, string password, out string mensajeError);
}
