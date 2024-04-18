using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanGamez.Models;

namespace PanGamez.Controllers
{
    public class CostoMantenimientoController : Controller
    {
        // GET: CostoMantenimientoController
        public IActionResult Index()
        {
            return View();
        }

        // GET: CostoMantenimientoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostoMantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CostoMantenimiento model)
        {
            if (ModelState.IsValid)
            {
                // Aquí implementa la lógica para calcular el costo de mantenimiento
                // usando los datos proporcionados en el modelo
                // y luego retorna la vista de resultados con el resultado del cálculo
                return View("Index", model);
            }
            else
            {
                // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
                return View();
            }
        }
    }
    
}
