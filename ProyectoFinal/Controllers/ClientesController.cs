using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class ClientesController : Controller
    {
       ClientesDatos clientesDatos = new ClientesDatos();
        public IActionResult Listar()
        {
            var oLista = clientesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarNuevo(Clientes oclientes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clientesDatos.Guardar(oclientes);

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
            var oclientes = clientesDatos.Obtener(id);

            return View(oclientes);
        }
        [HttpPost]
        public IActionResult Editar(Clientes oclientes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clientesDatos.Editar(oclientes);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var oclientes = clientesDatos.Obtener(id);

            return View(oclientes);
        }
        [HttpPost]
        public IActionResult Eliminar(Clientes oclientes)
        {
            var respuesta = clientesDatos.Eliminar(oclientes.CLIENTES_COD);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}