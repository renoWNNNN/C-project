using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inkTHINK.Infrastructure.Data;
using inkTHINK.Domain.Entities;

namespace inkTHINK.Web.Controllers
{
    public class TaxRulesController : Controller
    {
        private readonly AppDbContext _context;

        public TaxRulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TaxRules
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxRules.ToListAsync());
        }

        // GET: TaxRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var rule = await _context.TaxRules.FirstOrDefaultAsync(m => m.Id == id);
            if (rule == null) return NotFound();

            return View(rule);
        }

        // GET: TaxRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxRules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxRule rule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rule);
        }

        // GET: TaxRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var rule = await _context.TaxRules.FindAsync(id);
            if (rule == null) return NotFound();

            return View(rule);
        }

        // POST: TaxRules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaxRule rule)
        {
            if (id != rule.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TaxRules.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rule);
        }

        // GET: TaxRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var rule = await _context.TaxRules.FirstOrDefaultAsync(m => m.Id == id);
            if (rule == null) return NotFound();

            return View(rule);
        }

        // POST: TaxRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rule = await _context.TaxRules.FindAsync(id);
            if (rule != null)
            {
                _context.TaxRules.Remove(rule);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
