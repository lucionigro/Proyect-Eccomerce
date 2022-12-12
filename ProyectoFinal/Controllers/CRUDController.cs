using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class CRUDController : Controller
    {
        /* Primero tengo que instanciar el objeto que voy a querer usar, en este caso es un objeto tipo UsuariosDatos
        y el metodo va a ser Listar, osea printear la informacion de la tabla*/

        UsuariosDatos usuariodatos = new UsuariosDatos();
        public IActionResult Listar()
        {
            var oLista = usuariodatos.Listar();
            //le decimos que queremos que como Return nos devuelta una vista (un formulario HTML)
            return View(oLista);
        }


        //muestra una ventana para añadir datos del nuevo registro
        public IActionResult GuardarForm()
        {
            return View();
        }

        //va a guardar el registro con los datos indicados
        [HttpPost]

        public IActionResult GuardarNuevo(Usuarios ousuarios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = usuariodatos.Guardar(ousuarios);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        /*public IActionResult Editar(int USUARIOS_CODIGO)
        {
            var ousuarios = UsuariosDatos.Obtener(USUARIOS_CODIGO);

            return View(ousuarios);
        }*/
    }
}
