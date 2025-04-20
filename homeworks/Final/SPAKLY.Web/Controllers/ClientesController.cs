using Microsoft.AspNetCore.Mvc;
using SPAKLY.Datos;
using SPAKLY.Modelos;

namespace SPAKLY.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly SPAKLYDbContext _context;

        public ClientesController(SPAKLYDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }
        public IActionResult Crear()
{
    return View();
}

        [HttpPost]
         public IActionResult Crear(Clientes cliente)
       {
           _context.Clientes.Add(cliente);
           _context.SaveChanges();
           return RedirectToAction("Index");
       }

      public IActionResult Editar(int id)
       {
           var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteID == id);
           if (cliente == null) return RedirectToAction("Index");
           return View(cliente);
      }

      [HttpPost]
        public IActionResult Editar(Clientes cliente)
      {
          _context.Clientes.Update(cliente);
           _context.SaveChanges();
            return RedirectToAction("Index");
      }

    [HttpPost]
       public IActionResult Eliminar(int id)
      {
        var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteID == id);
        if (cliente != null)
     {
         _context.Clientes.Remove(cliente);
         _context.SaveChanges();
     }
      return RedirectToAction("Index");
}
    }
}
