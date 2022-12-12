using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos

{
    //Agus
    public class ordenesProductosDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<OrdenesProductos> Listar()
        {
            var oLista = new List<OrdenesProductos>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_ordenes_productos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new OrdenesProductos()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            ORDENES_COD = Convert.ToInt32(dr["ordenes_cod"]),

                            ORDENES_PRODUCTOS_COD = Convert.ToInt32(dr["ordenes_productos_cod"]),

                            PRECIO_COMPRA = (float)Convert.ToDecimal(dr["precio_compra"]),

                            CANTIDAD_PRODUCTO = Convert.ToInt32(dr["cantidad_producto"]),

                            PRODUCTOS_COD = Convert.ToInt32(dr["productos_cod"])

                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(OrdenesProductos OordenesProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_ordenes_productos", conexion);
                    cmd.Parameters.AddWithValue("ordenes_cod", OordenesProductos.ORDENES_COD);
                    cmd.Parameters.AddWithValue("ordenes_prodcutos_cod", OordenesProductos.ORDENES_PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("precio_compra", OordenesProductos.PRECIO_COMPRA);
                    cmd.Parameters.AddWithValue("cantidad_producto", OordenesProductos.CANTIDAD_PRODUCTO);
                    cmd.Parameters.AddWithValue("productos_cod", OordenesProductos.PRODUCTOS_COD);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //DELETE
        //reemplazar el (int ---) por la primary de la tabla
        public bool Eliminar(int ORDENES_PRODUCTOS_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //en el Delete solamente va la primary key
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_eliminar_ordenes_productos", conexion);
                    cmd.Parameters.AddWithValue("ordenes_productos_cod", ORDENES_PRODUCTOS_COD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //CREATE
        public bool guardar(OrdenesProductos OordenesProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //En un Create se guardan todas las columnas de una tabla excepto la primary aclaro por las dudas
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_guardar_ordenes_prodcutos", conexion);
                    cmd.Parameters.AddWithValue("ordenes_cod", OordenesProductos.ORDENES_COD);
                    cmd.Parameters.AddWithValue("precio_compra", OordenesProductos.PRECIO_COMPRA);
                    cmd.Parameters.AddWithValue("cantidad_producto", OordenesProductos.CANTIDAD_PRODUCTO);
                    cmd.Parameters.AddWithValue("productos_cod", OordenesProductos.PRODUCTOS_COD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //READ BY
        //Reemplazar el (int ----) por la primary que vaya
        public OrdenesProductos obtener(int ORDENES_PRODUCTOS_COD)
        {
            var OordenesProductos = new OrdenesProductos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_ordenes_productos", conexion);
                cmd.Parameters.AddWithValue("ordenes_prodcutos_cod", ORDENES_PRODUCTOS_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        OordenesProductos.ORDENES_COD = Convert.ToInt32(dr["ordenes_cod"]);
                        OordenesProductos.ORDENES_PRODUCTOS_COD = Convert.ToInt32(dr["ordenes_productos_cod"]);
                        OordenesProductos.PRECIO_COMPRA = (float)Convert.ToDecimal(dr["precio_compra"]);
                        OordenesProductos.CANTIDAD_PRODUCTO = Convert.ToInt32(dr["cantidad_producto"]);
                        OordenesProductos.PRODUCTOS_COD = Convert.ToInt32(dr["productos_cod"]);
                    }
                }
            }
            return OordenesProductos;
        }
    }
}
