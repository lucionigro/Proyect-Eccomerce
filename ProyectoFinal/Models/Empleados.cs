using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal.Models
{
    public class Empleados
    {
        
        public int EMPLEADOS_CODIGO { get; set; }
        public string? NOMBRE { get; set; }
        public string? APELLIDO { get; set; }
        public string? TIPO_EMPLEADO { get; set; }
        public int USUARIOS_CODIGO { get; set; }
       

    }
}
