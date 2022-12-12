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
                            CLIENTES_COD = Convert.ToInt32(dr["Cliente_cod"]),
                            NOMBRE = dr["Nombre"].ToString(),
                            APELLIDO = dr["Apellido"].ToString(),
                            CORREO = dr["Correo"].ToString(),
                            TIPO_CLIENTE = dr["Tipo_cliente"].ToString(),
                            CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]),
                            RAZON_SOCIAL = dr["Razon_social"].ToString(),
                            USUARIOS_CODIGO = Convert.ToInt32(dr["Usuarios_codigo"])
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
                    cmd.Parameters.AddWithValue("Clientes_cod", oclientes.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("Nombre", oclientes.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", oclientes.APELLIDO);
                    cmd.Parameters.AddWithValue("Correo", oclientes.CORREO);
                    cmd.Parameters.AddWithValue("Tipo_cliente", oclientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oclientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("Razon_social", oclientes.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", oclientes.USUARIOS_CODIGO);
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
                    cmd.Parameters.AddWithValue("Clientes_cod", CLIENTES_COD);
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
                    cmd.Parameters.AddWithValue("Nombre", oclientes.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", oclientes.APELLIDO);
                    cmd.Parameters.AddWithValue("Correo", oclientes.APELLIDO);
                    cmd.Parameters.AddWithValue("Tipo_cliente", oclientes.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oclientes.CUIT_DNI);
                    cmd.Parameters.AddWithValue("Razon_social", oclientes.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", oclientes.USUARIOS_CODIGO);
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
                cmd.Parameters.AddWithValue("Clientes_cod", CLIENTES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oclientes.CLIENTES_COD = Convert.ToInt32(dr["Clientes_cod"]);
                        oclientes.NOMBRE = dr["Nombre"].ToString();
                        oclientes.APELLIDO = dr["Apellido"].ToString();
                        oclientes.CORREO = dr["Correo"].ToString();
                        oclientes.TIPO_CLIENTE = dr["Tipo_cliente"].ToString();
                        oclientes.CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]);
                        oclientes.RAZON_SOCIAL = dr["Razon_social"].ToString();
                        oclientes.USUARIOS_CODIGO = Convert.ToInt32(dr["Usuarios_codigo"]);
                    }
                }
            }
            return oclientes;
            //la reconcha de tu hermana
        }
    }
}
