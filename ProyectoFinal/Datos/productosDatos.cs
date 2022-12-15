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
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]),

                            NOMBRE = dr["nombre"].ToString(),

                            PRECIO = (float)Convert.ToDecimal(dr["PRECIO"]),

                            STOCK = Convert.ToInt32(dr["STOCK"]),

                            PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"])
                            

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
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", Oproductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("PROVEDORES_COD", Oproductos.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", Oproductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", Oproductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", Oproductos.STOCK);
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
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
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
        public bool Guardar(Productos Oproductos)
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
                    //cmd.Parameters.AddWithValue("PRODUCTOS_COD", Oproductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("PROVEDORES_COD", Oproductos.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", Oproductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", Oproductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", Oproductos.STOCK);
                    
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                //Console.WriteLine(Oproductos);
                respuesta = true;
            }
            catch (Exception e)
            {
                
                string error = e.Message;
                Console.WriteLine(error);
                respuesta = false;
            }
            return respuesta;
        }

        //READ BY
        //Reemplazar el (int ----) por la primary que vaya
        public Productos Obtener(int PRODUCTOS_COD)
        {
            var Oproductos = new Productos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_poductos", conexion);
                cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Oproductos.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]);
                        Oproductos.NOMBRE = dr["NOMBRE"].ToString();
                        Oproductos.PRECIO = (float)Convert.ToDecimal(dr["PRECIO"]);
                        Oproductos.STOCK = Convert.ToInt32(dr["STOCK"]);
                        Oproductos.PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]);
                        
                    }
                }
            }
            return Oproductos;
        }
    }
}
