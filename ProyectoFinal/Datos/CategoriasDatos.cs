﻿using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    //Lucio
    public class CategoriasDatos
    {
        //READ
        //en la lista meter adentro del <> el modelo que corresponda
        public List<Categorias> Listar()
        {
            var oLista = new List<Categorias>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla 
                SqlCommand cmd = new SqlCommand("sp_leer_categorias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        oLista.Add(new Categorias()
                        {
                            //reemplazen por los valores de la columna, sea string o int
                            CATEGORIA_COD = Convert.ToInt32(dr["CATEGORIA_COD"]),
                            DETALLE = dr["DETALLE"].ToString()

                        });                                        
                }
            }
            return oLista;
        }

        //UPDATE
        // editar adentro del parentesis el modelo que corresponda y ocategorias dejen la o (objeto) y reemplazen por lo que vaya, ejemplo ousuarios
        public bool Editar(Categorias ocategorias)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                    SqlCommand cmd = new SqlCommand("sp_Editar_categorias", conexion);
                    cmd.Parameters.AddWithValue("CATEGORIA_COD", ocategorias.CATEGORIA_COD);
                    cmd.Parameters.AddWithValue("DETALLE", ocategorias.DETALLE);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e) {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //DELETE
        //reemplazar el (int ---) por la primary de la tabla
        public bool Eliminar (int CATEGORIA_COD)
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
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_categorias", conexion);
                    cmd.Parameters.AddWithValue("CATEGORIA_COD", CATEGORIA_COD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta =true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //CREATE
        public bool Guardar(Categorias ocategorias)
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
                    SqlCommand cmd = new SqlCommand("sp_guardar_categorias", conexion);
                    cmd.Parameters.AddWithValue("DETALLE", ocategorias.DETALLE);
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
        public Categorias Obtener(int CATEGORIA_COD)
        {
            var ocategorias = new Categorias();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //en la linea de codigo de abajo, adentro del ("") va el nombre del procedimiento armado especificamente para la tabla
                SqlCommand cmd = new SqlCommand("sp_obtener_categorias", conexion);
                cmd.Parameters.AddWithValue("CATEGORIA_COD", CATEGORIA_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ocategorias.CATEGORIA_COD = Convert.ToInt32(dr["CATEGORIA_COD"]);
                        ocategorias.DETALLE = dr["DETALLE"].ToString();
                    }
                }
            }
            return ocategorias;
        }
    }
}
