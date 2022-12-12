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
                            SUPERVISOR_CODIGO = Convert.ToInt32(dr["SUPERVISOR_CODIGO"]),
                            TIPO_EMPLEADO = dr["TIPO_EMPLEADO"].ToString(),
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
                    cmd.Parameters.AddWithValue("Empleados_cod", oempleados.EMPLEADOS_CODIGO);
                    cmd.Parameters.AddWithValue("Supervisor_cod", oempleados.SUPERVISOR_CODIGO);
                    cmd.Parameters.AddWithValue("Tipo_empleado", oempleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("Apellido_supervisor", oempleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("Nombre", oempleados.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", oempleados.APELLIDO);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", oempleados.USUARIOS_CODIGO);                    
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
                    cmd.Parameters.AddWithValue("Empleados_cod", EMPLEADOS_CODIGO);
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
                    cmd.Parameters.AddWithValue("Supervisor_cod", oempleados.SUPERVISOR_CODIGO);
                    cmd.Parameters.AddWithValue("Tipo_empleado", oempleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("Apellido_supervisor", oempleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("Nombre", oempleados.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", oempleados.APELLIDO);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", oempleados.USUARIOS_CODIGO);
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
                cmd.Parameters.AddWithValue("Empleados_cod", EMPLEADOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oempleados.EMPLEADOS_CODIGO = Convert.ToInt32(dr["Empleados_cod"]);
                        oempleados.SUPERVISOR_CODIGO = Convert.ToInt32(dr["Supervisor_cod"]);
                        oempleados.TIPO_EMPLEADO = dr["Tipo_empleado"].ToString();
                        oempleados.APELLIDO_SUPERVISOR = dr["Apellido_supervisor"].ToString();
                        oempleados.NOMBRE = dr["Nombre"].ToString();
                        oempleados.APELLIDO = dr["Apellido"].ToString();                        
                        oempleados.USUARIOS_CODIGO = Convert.ToInt32(dr["Usuarios_codigo"]);
                    }
                }
            }
            return oempleados;
        }
    }
}
