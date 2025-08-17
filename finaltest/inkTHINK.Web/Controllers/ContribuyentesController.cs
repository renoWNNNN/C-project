using Microsoft.AspNetCore.Mvc;
using inkTHINK.Infrastructure.Data;
using inkTHINK.Domain.Entities;

namespace inkTHINK.Web.Controllers
{
    public class ContribuyentesController : Controller
    {
        private readonly AppDbContext _context;

        public ContribuyentesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contribuyentes = _context.Contribuyentes.ToList();
            return View(contribuyentes);
        }
    }
}
