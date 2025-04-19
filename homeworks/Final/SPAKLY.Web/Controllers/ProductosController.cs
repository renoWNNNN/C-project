using Microsoft.AspNetCore.Mvc;
using SPAKLY.Modelos; 
using System.Collections.Generic;

namespace SPAKLY.Web.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            var Productos = new List<Productos>
            {
                new Productos { Nombre = "Acer Nitro 16", Descripcion = "AMD Ryzen 7 7000 Series", Precio = 54124.00M, Stock = 10 },
                new Productos { Nombre = "Titan 18 HX A14V", Descripcion = "Intel® Core™ i9 14900HX", Precio = 332416.00M, Stock = 5 }
            };

            return View(Productos);
        }
    }
}
