using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class OrdenesProductosController : Controller
    {
        ordenesProductosDatos ordenesproductosdatos = new ordenesProductosDatos();
        public IActionResult Listar()
        {
            var oLista = ordenesproductosdatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(OrdenesProductos OordenesProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesproductosdatos.Guardar(OordenesProductos);

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
            var OordenesProductos = ordenesproductosdatos.Obtener(id);

            return View(OordenesProductos);
        }
        [HttpPost]
        public IActionResult Editar(OrdenesProductos OordenesProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesproductosdatos.Editar(OordenesProductos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var OordenesProductos = ordenesproductosdatos.Obtener(id);

            return View(OordenesProductos);
        }
        [HttpPost]
        public IActionResult Eliminar(OrdenesProductos OordenesProductos)
        {
            var respuesta = ordenesproductosdatos.Eliminar(OordenesProductos.ORDENESPRODUCTOSCOD);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
