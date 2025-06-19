using System.ComponentModel.DataAnnotations;

namespace CentroEventos.Aplicacion.Enums
{
    public enum EnumEstadoAsistencia
    {
        [Display(Name = "Pendiente")]
        pendiente,
        [Display(Name = "Presente")]
        presente,
        [Display(Name = "Ausente")]
        ausente
    }

}
