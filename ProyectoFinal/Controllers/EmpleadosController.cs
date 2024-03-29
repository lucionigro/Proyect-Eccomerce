﻿using Microsoft.AspNetCore.Mvc;
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
        //Siempre para crear vistas parense en el primer guardar que vean, primer editar y primer eliminar
        //Para que no se mareen si ven dos controladores editar, la vista siempre sea crea sobre el primero
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Empleados oempleados)
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
        public IActionResult Editar(int id)
        {
            var oempleados = empleadosDatos.Obtener(id);

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


        public IActionResult Eliminar(int id)
        {
            var oempleados = empleadosDatos.Obtener(id);

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
