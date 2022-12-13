using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class EmpleadosController : Controller
    {
        //Primero se define al objeto tipo EmpleadoDatos y se lo llama:
        EmpleadosDatos empleadosDatos = new EmpleadosDatos();

        //Despues de cambiar por los datos correspondientes, click derecho en Listar y crear vista razor
        public IActionResult Listar()
        {
            var oLista = empleadosDatos.Listar();
            return View(oLista);
        }
        //Click derecho en Guardarform y añadir vista
        //Esta vista solamente devuelve la Lista a guardar
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
        //lo mismo que en los otros dos :D
        public IActionResult Editar(int EMPLEADOS_CODIGO)
        {
            var oempleados = empleadosDatos.Obtener(EMPLEADOS_CODIGO);

            return View(oempleados);
        }
        [HttpPost]
        public IActionResult Editar(Empleados oempleados)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = empleadosDatos.Editar(oempleados);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int EMPLEADOS_CODIGO)
        {
            var oempleados = empleadosDatos.Obtener(EMPLEADOS_CODIGO);

            return View(oempleados);
        }
        [HttpPost]
        public IActionResult Eliminar(Empleados oempleados)
        {
            var respuesta = empleadosDatos.Eliminar(oempleados.EMPLEADOS_CODIGO);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
