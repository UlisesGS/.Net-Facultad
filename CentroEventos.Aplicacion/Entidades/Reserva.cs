using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entidades
{
    public class Reserva
    {
        
        public Reserva() {}

        public Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EnumEstadoAsistencia estadoAsistencia)
        {
            Id = id;
            PersonaId = personaId;
            EventoDeportivoId = eventoDeportivoId;
            FechaAltaReserva = fechaAltaReserva;
            EstadoAsistencia = estadoAsistencia;
        }
        
        public int Id { get; set; }

        public int PersonaId { get; set; }

        public int EventoDeportivoId { get; set; }

        public DateTime FechaAltaReserva { get; set; }

        public EnumEstadoAsistencia EstadoAsistencia { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id,-4} | Persona ID: {PersonaId,-5} | Evento ID: {EventoDeportivoId,-5} | Fecha Alta: {FechaAltaReserva:yyyy-MM-dd} | Estado: {EstadoAsistencia,-9}";
        }

    }
}
