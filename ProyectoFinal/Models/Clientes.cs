using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;


namespace ProyectoFinal.Models
{
    public class Clientes
    {

        public int CLIENTES_COD { get; set; }
        public string? TIPO_CLIENTE { get; set; }
        public string? RAZON_SOCIAL { get; set; }
        public int CUIT_DNI { get; set; }
        public string? NOMBRE { get; set; }
        public string? APELLIDO { get; set; }       
        public int USUARIOS_CODIGO { get; set; }

    }
}
