using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    //Lucio
    public class OrdenesDatos
    {
        public List<Ordenes> Listar()
        {
            var oLista = new List<Ordenes>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_leer_ordenes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Ordenes()
                        {
                            ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]),                            
                            VENDEDOR = dr["VENDEDOR"].ToString(),
                            FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString(),
                            CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]),
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]),

                        });
                }
            }
            return oLista;
        }

        //UPDATE
        public bool Editar(Ordenes oordenes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_ordenes", conexion);
                    cmd.Parameters.AddWithValue("ORDENES_COD", oordenes.ORDENES_COD);                    
                    cmd.Parameters.AddWithValue("VENDEDOR", oordenes.VENDEDOR);                    
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oordenes.FECHA_ENTREGA);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oordenes.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", oordenes.EMPLEADOS_CODIGO);

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
        public bool Eliminar(int ORDENES_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar_ordenes", conexion);
                    cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
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
        public bool Guardar(Ordenes oordenes)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar_ordenes", conexion);
                    cmd.Parameters.AddWithValue("VENDEDOR", oordenes.VENDEDOR);                    
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oordenes.FECHA_ENTREGA);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oordenes.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", oordenes.EMPLEADOS_CODIGO);

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
        public Ordenes Obtener(int ORDENES_COD)
        {
            var oordenes = new Ordenes();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_ordenes", conexion);
                cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oordenes.ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]);                        
                        oordenes.VENDEDOR = dr["VENDEDOR"].ToString();
                        oordenes.FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString();
                        oordenes.CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]);
                        oordenes.EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_CODIGO"]);
                    }
                }
            }
            return oordenes;
        }
    }
}
