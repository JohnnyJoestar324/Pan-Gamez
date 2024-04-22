using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanGamez.Controllers
{
    public class LtcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateLTC(int numeroPeriodos, string requerimientosBrutos, double costoOrdenar, double costoMantenimiento)
        {
            var results = new List<LTC>();

            // Convertir la cadena de requerimientos brutos en una lista de enteros
            var unidades = requerimientosBrutos.Split(',').Select(int.Parse).ToList();

            // Inicializamos los valores para el primer período
            var periodo = 0;
            var unidadesPeriodo = unidades[0];
            var periodosMantenidos = 0;
            var costoMantenimientoAcumulado = 0.0;

            // Iteramos sobre cada período
            for (int i = 0; i < numeroPeriodos; i++)
            {
                // Calculamos el costo de mantenimiento para el período actual
                var costoMantenimientoPeriodo = unidadesPeriodo * periodosMantenidos * costoMantenimiento;

                // Calculamos el costo de mantenimiento acumulado
                costoMantenimientoAcumulado += costoMantenimientoPeriodo;

                // Guardamos los resultados en la lista
                results.Add(new LTC
                {
                    Periodo = periodo,
                    Unidades = unidadesPeriodo,
                    PeriodosMantenidos = periodosMantenidos,
                    CostoMantenimiento = costoMantenimientoPeriodo,
                    CostoMantenimientoAcumulado = costoMantenimientoAcumulado
                });
                // Si el costo de mantenimiento acumulado supera el costo de ordenar, reiniciamos los valores
                if (costoMantenimientoAcumulado >= costoOrdenar)
                {
                    periodo = 1;
                    periodosMantenidos = 0;
                    costoMantenimientoAcumulado = 0.0;
                }
                else
                {
                    // Avanzamos al siguiente período
                    periodo++;
                    periodosMantenidos++;
                }

                // Actualizamos las unidades para el próximo período
                if (i < unidades.Count - 1)
                {
                    unidadesPeriodo = unidades[i + 1];
                }
            }
            ViewBag.CostoOrdenar = costoOrdenar;
            // Retornamos la vista con los resultados
            return View("Index", results);
        }
    }
}


