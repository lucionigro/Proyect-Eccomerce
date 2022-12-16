using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesDatos OrdenesDatos = new OrdenesDatos();
        public IActionResult Listar()
        {
            var oLista = OrdenesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Ordenes oordenes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = OrdenesDatos.Guardar(oordenes);

            Console.WriteLine(respuesta);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var oordenes = OrdenesDatos.Obtener(id);

            return View(oordenes);
        }
        [HttpPost]
        public IActionResult Editar(Ordenes oordenes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = OrdenesDatos.Editar(oordenes);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var oordenes = OrdenesDatos.Obtener(id);

            return View(oordenes);
        }
        [HttpPost]
        public IActionResult Eliminar(Ordenes oordenes)
        {
            var respuesta = OrdenesDatos.Eliminar(oordenes.ORDENES_COD);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
