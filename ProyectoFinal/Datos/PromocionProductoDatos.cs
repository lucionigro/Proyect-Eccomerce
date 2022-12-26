using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class PromocionProductoDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<PromocionProducto> Listar()
        {
            var oLista = new List<PromocionProducto>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_promocion_producto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new PromocionProducto()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]),
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]), //A CHECKEARR
                            NUMERO_PROMOCION = Convert.ToInt32(dr["Numero_promocion"]),
                            FECHA_INICIO = dr["FECHA_INICIO"].ToString(),
                            FECHA_FINAL = dr["FECHA_FINAL"].ToString()
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(PromocionProducto opromocionproducto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_promocion_productos", conexion);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", opromocionproducto.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", opromocionproducto.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("NUMERO_PROMOCION", opromocionproducto.NUMERO_PROMOCION);
                    cmd.Parameters.AddWithValue("FECHA_INICIO", opromocionproducto.FECHA_INICIO);
                    cmd.Parameters.AddWithValue("FECHA_FINAL", opromocionproducto.FECHA_FINAL);
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
        public bool Eliminar(int NUMERO_PROMOCION)
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
                    SqlCommand cmd = new SqlCommand("sp_eliminar_promocion_producto", conexion);
                    
                    cmd.Parameters.AddWithValue("NUMERO_PROMOCION", NUMERO_PROMOCION);
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
        public bool Guardar(PromocionProducto opromocionproducto)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_promocion_producto", conexion);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", opromocionproducto.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", opromocionproducto.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("FECHA_INICIO", opromocionproducto.FECHA_INICIO);
                    cmd.Parameters.AddWithValue("FECHA_FINAL", opromocionproducto.FECHA_FINAL);
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
        public PromocionProducto Obtener(int NUMERO_PROMOCION)
        {
            var opromocionproducto = new PromocionProducto();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_promocion_producto", conexion);
                cmd.Parameters.AddWithValue("NUMERO_PROMOCION", NUMERO_PROMOCION);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        opromocionproducto.PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]);
                        opromocionproducto.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_CODIGO"]);
                        opromocionproducto.NUMERO_PROMOCION = Convert.ToInt32(dr["NUMERO_PROMOCION"]);
                        opromocionproducto.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                        opromocionproducto.FECHA_FINAL = dr["FECHA_FINAL"].ToString();
                    }
                }
            }
            return opromocionproducto;
        }
    }
}
