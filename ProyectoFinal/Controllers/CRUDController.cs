using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class CRUDController : Controller
    {
        EmpleadosDatos empleadosDatos = new EmpleadosDatos();
        public IActionResult Listar()
        {
            var oLista = empleadosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarNuevo(Empleados oempleados)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = empleadosDatos.Guardar(oempleados);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
