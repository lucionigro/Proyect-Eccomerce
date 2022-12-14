namespace ProyectoFinal.Models
{
    public class Promociones
    {
        public int PROMOCIONES_COD { get; set; }

        public string? NOMBRE { get; set; }

        public float DESCUENTO { get; set; } //ESTABA COMO FLOAT, LO CAMBIO A DECIMAL PARA QUE COINCIDA CON EL MODELO DE LA BD
    }
}
