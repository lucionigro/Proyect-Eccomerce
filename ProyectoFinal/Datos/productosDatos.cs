using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos

{
    //Agus
    public class productosDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<Productos> Listar()
        {
            var oLista = new List<Productos>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_productos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Productos()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            PRODUCTOS_COD = Convert.ToInt32(dr["productos_cod"]),

                            NOMBRE = dr["nombre"].ToString(),

                            PRECIO = (float)Convert.ToDecimal(dr["precio"]),

                            STOCK = Convert.ToInt32(dr["stock"]),

                            PROOVEDORES_COD = Convert.ToInt32(dr["provedores_cod"])

                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(Productos Oproductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_productos", conexion);
                    cmd.Parameters.AddWithValue("productos_cod", Oproductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("nombre", Oproductos.NOMBRE);
                    cmd.Parameters.AddWithValue("precio", Oproductos.PRECIO);
                    cmd.Parameters.AddWithValue("stock", Oproductos.STOCK);
                    cmd.Parameters.AddWithValue("provedores_cod", Oproductos.PROOVEDORES_COD);

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
        public bool Eliminar(int PRODUCTOS_COD)
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
                    SqlCommand cmd = new SqlCommand("sp_eliminar_productos", conexion);
                    cmd.Parameters.AddWithValue("ordenes_productos_cod", PRODUCTOS_COD);
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
        public bool guardar(Productos Oproductos)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_productos", conexion);
                    cmd.Parameters.AddWithValue("nombre", Oproductos.NOMBRE);
                    cmd.Parameters.AddWithValue("precio", Oproductos.PRECIO);
                    cmd.Parameters.AddWithValue("stock", Oproductos.STOCK);
                    cmd.Parameters.AddWithValue("provedores_cod", Oproductos.PROOVEDORES_COD);
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
        public Productos obtener(int PRODUCTOS_COD)
        {
            var Oproductos = new Productos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_productos", conexion);
                cmd.Parameters.AddWithValue("productos_cod", PRODUCTOS_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Oproductos.PRODUCTOS_COD = Convert.ToInt32(dr["productos_cod"]);
                        Oproductos.NOMBRE = dr["nombre"].ToString();
                        Oproductos.PRECIO = (float)Convert.ToDecimal(dr["precio"]);
                        Oproductos.STOCK = Convert.ToInt32(dr["stock"]);
                        Oproductos.PROOVEDORES_COD = Convert.ToInt32(dr["provedores_cod"]);
                    }
                }
            }
            return Oproductos;
        }
    }
}
