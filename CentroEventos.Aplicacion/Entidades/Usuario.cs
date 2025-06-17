using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion;

public class Usuario
{

    public Usuario() { }

    public Usuario(int id, string nombre, string apellido, string email, string password)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        HashPassword = password;
    }

    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string HashPassword { get; set; } = null!; // no se si se necesita creeria q si
    public List<EnumPermiso> Permisos { get; set; } = new List<EnumPermiso>();  // lo pense asi no se si esta bien 
}
