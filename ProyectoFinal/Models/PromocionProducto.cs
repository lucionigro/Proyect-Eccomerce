namespace ProyectoFinal.Models
{
    public class PromocionProducto
    {
        public int PROMOCIONES_CODIGO { get; set; }

        public int PRODUCTOS_COD { get; set; }
        public int NUMERO_PROMOCION { get; set; }

        public string? FECHA_INICIO { get; set; }

        public string? FECHA_FINAL { get; set; }

        //DESCOMENTE FECHA INCIO Y FECHA FINAL, Y CAMBIE EL NOMBRE DE FECHA INICIAL PARA QUE COINCIDA CON LA BD Y PODER USARLO EN EL CRUD
    }
}
