
using Microsoft.Build.Framework;

namespace ProyectoFinal.Models
{
    public class Usuarios
    {
        public int USUARIOS_CODIGO { get; set; }
        [Required]
        public string? CONTRASEÑA { get; set; } 

        public int PERFILES_CODIGO { get; set; }

        [Required]
        public string? CORREO { get; set; }
    }
}
