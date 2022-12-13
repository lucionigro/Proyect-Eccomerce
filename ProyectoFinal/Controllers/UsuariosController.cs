using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosDatos usuariosDatos = new UsuariosDatos();
        public IActionResult Listar()
        {
            var oLista = usuariosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarNuevo(Usuarios ousuarios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = usuariosDatos.Guardar(ousuarios);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int USUARIOS_CODIGO)
        {
            var ousuarios = usuariosDatos.Obtener(USUARIOS_CODIGO);

            return View(ousuarios);
        }
        [HttpPost]
        public IActionResult Editar(Usuarios ousuarios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = usuariosDatos.Editar(ousuarios);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int USUARIOS_CODIGO)
        {
            var ousuarios = usuariosDatos.Obtener(USUARIOS_CODIGO);

            return View(ousuarios);
        }
        [HttpPost]
        public IActionResult Eliminar(Usuarios ousuarios)
        {
            var respuesta = usuariosDatos.Eliminar(ousuarios.USUARIOS_CODIGO);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
