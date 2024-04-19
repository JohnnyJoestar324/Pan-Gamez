using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;

namespace PanGamez.Controllers
{
    public class CostoMantenimientoController : Controller
    {
        // GET: CostoMantenimiento/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: CostoMantenimiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CostoMantenimiento model)
        {
            if (ModelState.IsValid)
            {
                // Verificar si se conoce el número de fallas
                double? numeroFallas = null;
                if (model.NumeroFallas > 0)
                {
                    // El número de fallas es conocido
                    numeroFallas = (int)model.NumeroFallas;
                    
                }
                else if (model.HorasTrabajo.HasValue && model.Mtbf.HasValue)
                {
                    // Calcular el número de fallas utilizando HorasTrabajo / MTBF
                    double horasTrabajo = model.HorasTrabajo.Value;
                    double mtbf = model.Mtbf.Value;
                    numeroFallas = (int)Math.Round(horasTrabajo / mtbf);
                    //numeroFallas = numeroFallas = (int)Math.Round(model.HorasTrabajo / model.Mtbf);
                }

                // Calcular el costo de mantenimiento correctivo
                double costoMantenimientoCorrectivo = numeroFallas.Value * ((((model.DuracionTarea + model.RetrasoLogistico) * model.CostoHoraTrabajo) + model.Repuestos + model.TareasAdicionales) + ((model.DuracionTarea * model.CostoUnitarioParada) + model.CostoFallaUnica));

                // Guardar el resultado en ViewData para pasarlo a la vista
                ViewData["MaintenanceCost"] = costoMantenimientoCorrectivo;

                // Retorna la vista "Index" con el modelo
                return View("Index", model);
            }
            else
            {
                // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
                return View("Index", model); // Aquí deberías redirigir a la vista "Index" en lugar de "Create"
            }
        }
    }

}
