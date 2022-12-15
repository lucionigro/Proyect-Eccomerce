using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class EmpleadosDatos
    {
        public List<Empleados> Listar()
        {
            var oLista = new List<Empleados>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_leer_empleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Empleados()
                        {
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]),                           
                            TIPO_EMPLEADO = Convert.ToInt32(dr["TIPO_EMPLEADO"]),
                            APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString(),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),                            
                            //USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"])
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        public bool Editar(Empleados oempleados)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_empleados", conexion);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", oempleados.EMPLEADOS_CODIGO);
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oempleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oempleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oempleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oempleados.APELLIDO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oempleados.USUARIOS_CODIGO);                    
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
        public bool Eliminar(int EMPLEADOS_CODIGO)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar_empleados", conexion);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
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
        public bool Guardar(Empleados oempleados)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar_empleados", conexion);                    
                    
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oempleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oempleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oempleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oempleados.APELLIDO);
                    cmd.Parameters.AddWithValue("USUARIOS_CODIGO", oempleados.USUARIOS_CODIGO);
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
        public Empleados Obtener(int EMPLEADOS_CODIGO)
        {
            var oempleados = new Empleados();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_empleados", conexion);
                cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oempleados.EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]);
                        
                        oempleados.TIPO_EMPLEADO = Convert.ToInt32(dr["TIPO_EMPLEADO"]);
                        oempleados.APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString();
                        oempleados.NOMBRE = dr["NOMBRE"].ToString();
                        oempleados.APELLIDO = dr["APELLIDO"].ToString();                        
                        oempleados.USUARIOS_CODIGO = Convert.ToInt32(dr["USUARIOS_CODIGO"]);
                    }
                }
            }
            return oempleados;
        }
    }
}
