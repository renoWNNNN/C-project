using Microsoft.AspNetCore.Mvc;
using inkTHINK.Infrastructure.Data;
using inkTHINK.Domain.Entities;

namespace inkTHINK.Web.Controllers
{
    public class TaxRulesController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public IActionResult Index()
        {
            var rules = _context.TaxRules.ToList();
            return View(rules);
        }
    }
}
