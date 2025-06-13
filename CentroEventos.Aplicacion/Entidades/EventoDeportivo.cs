namespace CentroEventos.Aplicacion.Entidades
{
    public class EventoDeportivo
    {
        public EventoDeportivo() {}

        public EventoDeportivo(int id, int responsableId, int cupoMaximo, DateTime fechaHoraInicio, double duracionHoras, string nombre, string descripcion)
        {
            Id = id;
            ResponsableId = responsableId;
            CupoMaximo = cupoMaximo;
            FechaHoraInicio = fechaHoraInicio;
            DuracionHoras = duracionHoras;
            Nombre = nombre;
            Descripcion = descripcion;
        }
 
        public int Id { get; set; }
        public int ResponsableId { get; set; }
        public int CupoMaximo { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public double DuracionHoras { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public override string ToString()
        {
            return $"ID: {Id,-4} | Nombre: {Nombre,-10} | Descripcion: {Nombre,-10} | Inicio: {FechaHoraInicio:yyyy-MM-dd HH:mm} | Duración: {DuracionHoras,5:F2} h | Cupo: {CupoMaximo,-4} | Responsable ID: {ResponsableId,-4}";
        }
    }
}
