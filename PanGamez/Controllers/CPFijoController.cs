using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;

namespace PanGamez.Controllers
{
    public class CPFijoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Calculate(CPfijo model)
        {
            if (ModelState.IsValid)
            {
                int D = model.Demanda;

                int Q = model.InventarioPedido;

                int SS = model.InventarioSeguridad;

                //Calcular Costo Promedio por Stock
                int I = (Q * 2) / SS;

                //Calculo de retacion de inventario
                int RotacionInventario = D / I;

                string analisisRespuesta = $"El costo promedio fijo es de: {I}." +
                    $" La rotacion de inventario es: {RotacionInventario}.";

                //Pasando resultados a la vista desde este controlador
                ViewData["CPfijo"] = analisisRespuesta;

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
