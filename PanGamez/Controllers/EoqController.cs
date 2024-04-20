using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;

namespace PanGamez.Controllers
{
    public class EoqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: EOQ/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(EOQ model)
        {
            if (ModelState.IsValid)
            {
                double D = model.Demanda;
                double S = model.CostoPedido;
                double H = model.CostoMantenimiento;
                double periodo = model.PeriodoSeleccionado;

                // Calcular EOQ
                double EOQ = Math.Sqrt((2 * D * periodo * S) / H);
                int eoqInt = (int)Math.Round(EOQ);
                string analysis = $"La cantidad de pedidos que la empresa deberá realizar es de {eoqInt} unidades para que el inventario no se agote durante el tiempo de entrega.";

                // Pasar el resultado a la vista
                ViewData["EOQ"] = analysis;
                ViewData["Resultado"] = eoqInt;

                return View("Index", model);
            }
            else
            {
                // Si el modelo no es válido, volver a mostrar el formulario con los errores
                return View("Index", model);
            }
        }
    }
}
