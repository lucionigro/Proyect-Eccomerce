using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class ProveedoresDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<Proveedores> Listar()
        {
            var oLista = new List<Proveedores>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_proveedores", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Proveedores()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            CUIT = Convert.ToInt32(dr["CUIT"])
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(Proveedores oproveedores)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_proveedores", conexion);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", oproveedores.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oproveedores.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oproveedores.APELLIDO);
                    cmd.Parameters.AddWithValue("CUIT", oproveedores.CUIT);
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
        public bool Eliminar(int PROVEEDORES_COD)
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
                    SqlCommand cmd = new SqlCommand("sp_eliminar_proveedores", conexion);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", PROVEEDORES_COD);
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
        public bool Guardar(Proveedores oproveedores)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_proveedores", conexion);
                    cmd.Parameters.AddWithValue("NOMBRE", oproveedores.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oproveedores.APELLIDO);
                    cmd.Parameters.AddWithValue("CUIT", oproveedores.CUIT);
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
        public Proveedores Obtener(int PROVEEDORES_COD)
        {
            var oproveedores = new Proveedores();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_proveedores", conexion);
                cmd.Parameters.AddWithValue("PROVEEDORES_COD", PROVEEDORES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oproveedores.PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]);
                        oproveedores.NOMBRE = dr["NOMBRE"].ToString();
                        oproveedores.APELLIDO = dr["APELLIDO"].ToString();
                        oproveedores.CUIT = Convert.ToInt32(dr["CUIT"]);
                    }
                }
            }
            return oproveedores;
        }
    }
}

