using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class ProveedoresController : Controller
    {
        ProveedoresDatos ProveedoresDatos = new ProveedoresDatos();
        public IActionResult Listar()
        {
            var oLista = ProveedoresDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Proveedores oproveedores)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ProveedoresDatos.Guardar(oproveedores);

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
            var oproveedores = ProveedoresDatos.Obtener(id);

            return View(oproveedores);
        }
        [HttpPost]
        public IActionResult Editar(Proveedores oproveedores)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ProveedoresDatos.Editar(oproveedores);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var oproveedores = ProveedoresDatos.Obtener(id);

            return View(oproveedores);
        }
        [HttpPost]
        public IActionResult Eliminar(Proveedores oproveedores)
        {
            var respuesta = ProveedoresDatos.Eliminar(oproveedores.PROVEEDORES_COD);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
