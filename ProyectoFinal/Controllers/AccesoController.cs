using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Session;
using System.Drawing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace ProyectoFinal.Controllers
{
    public class AccesoController : Controller
    {
        

        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        using (SqlCommand cmd = new("sp_login", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = login.CORREO;
                            cmd.Parameters.Add("@CONTRASENIA", SqlDbType.VarChar).Value = login.CONTRASENIA;
                            conexion.Open();
                          
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                Response.Cookies.Append("user", "Bienvenido " + login.CORREO);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["error"] = "Error de credenciales";
                            }
                            conexion.Close();
                        }
                    }
                    return RedirectToAction("Login", "Acceso");
                }
            }
            catch (Exception)
            {
                return View("Login");
            }
           
            return View("Login");
        }


        public ActionResult Logout ()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
