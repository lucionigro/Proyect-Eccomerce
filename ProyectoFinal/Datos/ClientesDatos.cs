 using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    //Lucio
    public class ClientesDatos
    {
        public List<Clientes> Listar()
        {
            var oLista = new List<Clientes>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_leer_clientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Clientes()
                        {
                            CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]),
                            TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString(),
                            RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString(),
                            CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString() ,
                            USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"])
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        public bool Editar(Clientes oclientes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_clientes", conexion);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oclientes.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oclientes.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oclientes.APELLIDO);
                    
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oclientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oclientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oclientes.RAZON_SOCIAL);
                   
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oclientes.USUARIOS_CODIGO);
                    
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
        public bool Eliminar(int CLIENTES_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar_clientes", conexion);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
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
        public bool Guardar(Clientes oclientes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar_clientes", conexion);
                    
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oclientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oclientes.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oclientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("NOMBRE", oclientes.NOMBRE);                    
                    cmd.Parameters.AddWithValue("APELLIDO", oclientes.APELLIDO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oclientes.USUARIOS_CODIGO);
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
        public Clientes Obtener(int CLIENTES_COD)
        {
            var oclientes = new Clientes();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_clientes", conexion);
                cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oclientes.CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]);
                        oclientes.NOMBRE = dr["NOMBRE"].ToString();
                        oclientes.APELLIDO = dr["APELLIDO"].ToString();
                        
                        oclientes.TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString();
                        oclientes.CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]);
                        oclientes.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                        
                        oclientes.USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]);

                    }
                }
            }
            return oclientes;
           
        }
    }
}
