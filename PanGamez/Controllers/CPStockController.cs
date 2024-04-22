using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;

namespace PanGamez.Controllers
{
    public class CPStockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Calculate(CPstock model)
        {
            if(ModelState.IsValid)
            {
                int D = model.Demanda;
                int T = model.TiempoReposicion;
                int SS = model.InventarioSeguridad;

                //Calcular Costo Promedio por Stock
                int I = ((D * T) / 2) + SS;

                //Calculo de retacion de inventario
                int RotacionInventario = D / I;

                string analisisRespuesta = $"El costo promedio en Stock es de: {I}." +
                    $" La rotacion de inventario es: {RotacionInventario}.";

                //Pasando resultados a la vista desde este controlador
                ViewData["CPstock"] = analisisRespuesta;

                return View("Index", model);
            }
            else
            {
                //Si el modelo no es valido, muestra errores y formulario
                return View("Index", model);
            }

            
        }
    }
}
