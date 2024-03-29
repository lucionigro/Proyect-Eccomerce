﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;

namespace ProyectoFinal.Controllers
{
    public class ProductosController : Controller
    {
        productosDatos ProductosDatos = new productosDatos();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var oLista = ProductosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Productos Oproductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ProductosDatos.Guardar(Oproductos);

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
            var Oproductos = ProductosDatos.Obtener(id);

            return View(Oproductos);
        }
        [HttpPost]
        public IActionResult Editar(Productos Oproductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ProductosDatos.Editar(Oproductos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int id)
        {
            var Oproductos = ProductosDatos.Obtener(id);

            return View(Oproductos);
        }
        [HttpPost]
        public IActionResult Eliminar(Productos Oproductos)
        {
            var respuesta = ProductosDatos.Eliminar(Oproductos.PRODUCTOS_COD);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}