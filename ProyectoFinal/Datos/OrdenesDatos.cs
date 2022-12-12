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
                            ORDENES_COD = Convert.ToInt32(dr["Ordenes_cod"]),                            
                            VENDEDOR = dr["Vendedor"].ToString(),
                            FECHA_ENTREGA = dr["Fecha_entrega"].ToString(),                            
                            CLIENTES_COD = Convert.ToInt32(dr["Clientes_cod"]),
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["Empleados_cod"])                            
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
                    cmd.Parameters.AddWithValue("Ordenes_cod", oordenes.ORDENES_COD);                    
                    cmd.Parameters.AddWithValue("Vendedor", oordenes.VENDEDOR);                    
                    cmd.Parameters.AddWithValue("Fecha_entrega", oordenes.FECHA_ENTREGA);                    
                    cmd.Parameters.AddWithValue("Clientes_cod", oordenes.CLIENTES_COD);                    
                    cmd.Parameters.AddWithValue("Empleados_cod", oordenes.EMPLEADOS_CODIGO);                    
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
                    cmd.Parameters.AddWithValue("Ordenes_cod", ORDENES_COD);
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
                    cmd.Parameters.AddWithValue("Vendedor", oordenes.VENDEDOR);                    
                    cmd.Parameters.AddWithValue("Fecha_entrega", oordenes.FECHA_ENTREGA);                    
                    cmd.Parameters.AddWithValue("Clientes_cod", oordenes.CLIENTES_COD);                    
                    cmd.Parameters.AddWithValue("Empleados_cod", oordenes.EMPLEADOS_CODIGO);                                        
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
                cmd.Parameters.AddWithValue("Ordenes_cod", ORDENES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oordenes.ORDENES_COD = Convert.ToInt32(dr["Ordenes_cod"]);                        
                        oordenes.VENDEDOR = dr["Vendedor"].ToString();
                        oordenes.FECHA_ENTREGA = dr["Fecha_entrega"].ToString();                        
                        oordenes.CLIENTES_COD = Convert.ToInt32(dr["Clientes_cod"]);
                        oordenes.EMPLEADOS_CODIGO = Convert.ToInt32(dr["Empleados_cod"]);
                    }
                }
            }
            return oordenes;
        }
    }
}
