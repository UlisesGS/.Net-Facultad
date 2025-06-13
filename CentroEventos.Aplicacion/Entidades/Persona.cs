
namespace CentroEventos.Aplicacion.Entidades
{
    public class Persona
    {

        public Persona() {}

        public Persona(int id, int? dni, string nombre, string apellido, string email, long telefono)
        {
            Id = id;
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
        }

        public int Id { get; set; }
        public int? DNI { get; set; }
        public string Nombre { get; set;} = null!;
        public string Apellido { get; set;} = null!;
        public string Email { get; set;} = null!;
        public long Telefono { get; set;}


        public override string ToString()
        {
            return $"ID: {Id,-4} | DNI: {(DNI.HasValue ? DNI.Value.ToString() : "N/A"),-10} | Nombre: {Nombre,-15} | Apellido: {Apellido,-15} | Email: {Email,-25} | Teléfono: {Telefono}";
        }
    }
}
