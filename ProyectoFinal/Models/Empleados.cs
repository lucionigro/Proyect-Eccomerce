using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal.Models
{
    public class Empleados
    {
        [Required]
        public int EMPLEADOS_CODIGO { get; set; }
        [Required]
        public int SUPERVISOR_CODIGO { get; set; }
        [Required]
        public string? TIPO_EMPLEADO { get; set; }
        [Required]
        public string? APELLIDO_SUPERVISOR { get; set; }
        [Required]
        public string? NOMBRE { get; set; }
        [Required]
        public string? APELLIDO { get; set; }
        [Required]
        public int USUARIOS_CODIGO { get; set; }
    }
}
