using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class UsuariosDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<Usuarios> Listar()
        {
            var oLista = new List<Usuarios>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_usuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Usuarios()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            USUARIOS_CODIGO = Convert.ToInt32(dr["Usuarios_codigo"]),
                            CONTRASEÑA = dr["Contraseña"].ToString(),
                            PERFILES_CODIGO = Convert.ToInt32(dr["Perfiles_codigo"]),
                            CORREO = dr["Correo"].ToString()
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(Usuarios ousuarios)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_usuarios", conexion);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", ousuarios.USUARIOS_CODIGO);
                    cmd.Parameters.AddWithValue("Contraseña", ousuarios.CONTRASEÑA);
                    cmd.Parameters.AddWithValue("Perfiles_codigo", ousuarios.PERFILES_CODIGO);
                    cmd.Parameters.AddWithValue("Correo", ousuarios.CORREO);
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
        public bool Eliminar(int USUARIOS_CODIGO)
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
                    SqlCommand cmd = new SqlCommand("sp_eliminar_usuarios", conexion);
                    cmd.Parameters.AddWithValue("Usuarios_codigo", USUARIOS_CODIGO);
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
        public bool Guardar(Usuarios ousuarios)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_usuarios", conexion);
                    cmd.Parameters.AddWithValue("Contraseña", ousuarios.CONTRASEÑA);
                    cmd.Parameters.AddWithValue("Perfiles_codigo", ousuarios.PERFILES_CODIGO);
                    cmd.Parameters.AddWithValue("Correo", ousuarios.CORREO);
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
        public Usuarios Obtener(int USUARIOS_CODIGO)
        {
            var ousuarios = new Usuarios();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_usuarios", conexion);
                cmd.Parameters.AddWithValue("usuarios_codigo", USUARIOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ousuarios.USUARIOS_CODIGO = Convert.ToInt32(dr["usuarios_codigo"]);
                        ousuarios.CONTRASEÑA = dr["Contraseña"].ToString();
                        ousuarios.CORREO = dr["Correo"].ToString();
                        ousuarios.PERFILES_CODIGO = Convert.ToInt32(dr["Detalle"]);
                    }
                }
            }
            return ousuarios;
        }
    }
}

