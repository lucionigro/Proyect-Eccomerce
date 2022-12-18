using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class PerfilesController : Controller
    {
        perfilesDatos PerfilesDatos = new perfilesDatos();
        public IActionResult Listar()
        {
            var oLista = PerfilesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Perfiles Operfiles)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = PerfilesDatos.Guardar(Operfiles);

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
            var Operfiles = PerfilesDatos.Obtener(id);

            return View(Operfiles);
        }
        [HttpPost]
        public IActionResult Editar(Perfiles Operfiles)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = PerfilesDatos.Editar(Operfiles);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var Operfiles = PerfilesDatos.Obtener(id);

            return View(Operfiles);
        }
        [HttpPost]
        public IActionResult Eliminar(Perfiles Operfiles)
        {
            var respuesta = PerfilesDatos.Eliminar(Operfiles.PERFILES_CODIGO);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}