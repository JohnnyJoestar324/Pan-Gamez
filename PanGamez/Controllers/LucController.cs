using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;
using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PanGamez.Controllers
{
    public class LucController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateLUC(int Periodo, string RequerimientoBruto, double costoDeOrdenar, double costoMantenimiento)
        {
            var results = new List<LUC>();

            // Convertir la cadena de requerimientos brutos en una lista de enteros
            var unidades = RequerimientoBruto.Split(',').Select(int.Parse).ToList();

            // Inicializamos los valores para el primer período
            var periodo = 0;
            var unidadesPeriodo = unidades[0];
  
            bool primeraIteracion = true; // Bandera para identificar la primera iteración
            int sumaAnterior = 0;
            int sumaAnteriorRequerimiento = 0;
            double sumaAnteriorK = 0;
            double costoTotal;
            double costoTotalAnterior = 0; // Variable para almacenar el costoTotal anterior



            // Iteramos sobre cada período
            for (int i = 0; i < Periodo; i++)
            {

                // Obtenemos el valor de la fila actual
                var periodoActual = unidades[i];

                // Sumamos el valor actual con el valor de la fila anterior, si existe


                // Calculamos el costo de mantenimiento para el período actual
                var costoMantenimientoPeriodo = costoMantenimiento;



                var sumaConAnterior = (i +1) + sumaAnterior;
                sumaAnterior = sumaConAnterior;
                var sumaConAnteriorRequerimiento = unidadesPeriodo + sumaAnteriorRequerimiento;
                sumaAnteriorRequerimiento = sumaConAnteriorRequerimiento;

                if (primeraIteracion)
                {
                    sumaAnteriorK = 0; // Primera multiplicación con cero
                    primeraIteracion = false; // Desactivar la bandera después de la primera iteración
                    costoTotalAnterior = costoDeOrdenar;

                }

                else
                {
                    var SumaConAnteriorK = costoMantenimiento * sumaConAnterior * ((i+1) - 1);
                    sumaAnteriorK = SumaConAnteriorK;
                    costoTotal = costoTotalAnterior + sumaAnteriorK; // Sumar costoTotalAnterior con sumaAnteriorK
                    costoTotalAnterior = costoTotal; // Actualizar costoTotalAnterior
                }




                // costoTotal = item.costoDeOrdenar + sumaAnteriorK;
                var costoTotalUnidades = costoTotalAnterior / sumaConAnteriorRequerimiento;



                // Guardamos los resultados en la lista
                results.Add(new LUC
                {
                    Periodo = sumaConAnterior,
                    RequerimientoBruto = sumaConAnteriorRequerimiento,
                    costoDeOrdenar = costoDeOrdenar,
                    CostoMantenimiento = sumaAnteriorK,
                    CostoTotal = costoTotalAnterior,
                    CostoUTotalU = costoTotalUnidades
                }); ;
                
                // Actualizamos las unidades para el próximo período
                if (i < unidades.Count - 1)
                {
                    unidadesPeriodo = unidades[i + 1];
                }
            }
            ViewBag.CostoOrdenar = costoDeOrdenar;
            // Retornamos la vista con los resultados
            return View("Index", results);
        }
    }
}