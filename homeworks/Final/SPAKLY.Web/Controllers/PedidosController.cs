using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPAKLY.Datos;
using SPAKLY.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SPAKLY.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly SPAKLYDbContext _context;

        public PedidosController(SPAKLYDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pedidos = _context.Ordenes.ToList();
            return View(pedidos);
        }

        public IActionResult Crear()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "ClienteID", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Ordenes orden)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "ClienteID", "Nombre");
                return View(orden);
            }

            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var orden = _context.Ordenes.FirstOrDefault(o => o.IdPedido == id);
            if (orden == null)
                return RedirectToAction("Index");

            ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "ClienteID", "Nombre", orden.ClienteId);
            return View(orden);
        }

        [HttpPost]
        public IActionResult Editar(Ordenes orden)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "ClienteID", "Nombre", orden.ClienteId);
                return View(orden);
            }

            _context.Ordenes.Update(orden);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
{
    var pedido = _context.Ordenes
        .Include(o => o.Cliente)
        .FirstOrDefault(o => o.IdPedido == id);

    if (pedido == null)
        return RedirectToAction("Index");

    return View(pedido);
}
    
            [HttpPost]
            public IActionResult Eliminar(int id, Ordenes orden)
            {
                var pedido = _context.Ordenes.FirstOrDefault(o => o.IdPedido == id);
    
                if (pedido != null)
                {
                    _context.Ordenes.Remove(pedido);
                    _context.SaveChanges();
                }
    
                return RedirectToAction("Index");
    }
}
}
