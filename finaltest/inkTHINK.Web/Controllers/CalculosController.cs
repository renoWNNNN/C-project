using Microsoft.AspNetCore.Mvc;
using inkTHINK.Infrastructure.Data;
using inkTHINK.Domain.Entities;

namespace inkTHINK.Web.Controllers
{
    public class CalculosController : Controller
    {
        private readonly AppDbContext _context;

        public CalculosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var calculos = _context.Calculos.ToList();
            return View(calculos);
        }
    }
}
