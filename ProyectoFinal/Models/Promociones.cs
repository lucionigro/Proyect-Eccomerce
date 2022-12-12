namespace ProyectoFinal.Models
{
    public class Promociones
    {
        public int PROMOCIONES_CODIGO { get; set; }

        public string? NOMBRE { get; set; }

        public decimal DESCUENTO { get; set; } //ESTABA COMO FLOAT, LO CAMBIO A DECIMAL PARA QUE COINCIDA CON EL MODELO DE LA BD
    }
}
