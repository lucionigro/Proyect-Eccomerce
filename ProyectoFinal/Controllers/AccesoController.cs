using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
    [HttpPost]

    public IActionResult Login(Clientes oclientes)
    {
        var oLista = new List<Clientes>();
        var cn = new Conexion();
        using (var conexion = new SqlConnection(cn.getCadenaSQL()))
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_validar_usuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                    oLista.Add(new Clientes()
                    {
                        CORREO = dr["CORREO"].ToString(),
                        CONTRASENIA = dr["CONTRASENIA"].ToString(),
                    });
            }

        }
                                                                                            
    }
}
