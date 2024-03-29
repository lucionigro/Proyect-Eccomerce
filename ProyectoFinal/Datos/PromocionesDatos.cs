﻿using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class PromocionesDatos
    {

        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<Promociones> Listar()
        {
            var oLista = new List<Promociones>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_promociones", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Promociones()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]),

                            NOMBRE = dr["NOMBRE"].ToString(),

                            DESCUENTO = (float)Convert.ToDecimal(dr["DESCUENTO"])
                        });
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(Promociones opromociones)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_editar_promociones", conexion);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", opromociones.PROMOCIONES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", opromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", opromociones.DESCUENTO);
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
        public bool Eliminar(int PROMOCIONES_COD)
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
                    SqlCommand cmd = new SqlCommand("sp_eliminar_promociones", conexion);
                    cmd.Parameters.AddWithValue("PROMOCIONES_COD", PROMOCIONES_COD);
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
        public bool Guardar(Promociones opromociones)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_promociones", conexion);
                    cmd.Parameters.AddWithValue("NOMBRE", opromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", opromociones.DESCUENTO);
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
        public Promociones Obtener(int PROMOCIONES_COD)
        {
            var opromociones = new Promociones();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_promociones", conexion);
                cmd.Parameters.AddWithValue("PROMOCIONES_COD", PROMOCIONES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        opromociones.PROMOCIONES_COD = Convert.ToInt32(dr["PROMOCIONES_COD"]);
                        opromociones.NOMBRE = dr["NOMBRE"].ToString();
                        opromociones.DESCUENTO = (float)Convert.ToDecimal(dr["DESCUENTO"]);
                    }
                }
            }
            return opromociones;
        }
    }
}
