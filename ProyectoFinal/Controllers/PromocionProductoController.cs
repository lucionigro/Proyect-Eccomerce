using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class PromocionProductoController : Controller
    {
        PromocionProductoDatos promocionproducto = new PromocionProductoDatos();
        public IActionResult Listar()
        {
            var oLista = promocionproducto.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(PromocionProducto opromocionproducto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = promocionproducto.Guardar(opromocionproducto);

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
            var opromocionproducto = promocionproducto.Obtener(id);

            return View(opromocionproducto);
        }
        [HttpPost]
        public IActionResult Editar(PromocionProducto opromocionproducto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = promocionproducto.Editar(opromocionproducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var opromocionproducto = promocionproducto.Obtener(id);

            return View(opromocionproducto);
        }
        [HttpPost]
        public IActionResult Eliminar(PromocionProducto opromocionproducto)
        {
            var respuesta = promocionproducto.Eliminar(opromocionproducto.NUMERO_PROMOCION);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}