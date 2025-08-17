using Microsoft.AspNetCore.Mvc;
using inkTHINK.Domain.Entities;
using inkTHINK.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace inkTHINK.Web.Controllers
{
    public class ContribuyentesController : Controller
    {
        private readonly AppDbContext _context;

        public ContribuyentesController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contribuyentes.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var contribuyente = await _context.Contribuyentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuyente == null) return NotFound();

            return View(contribuyente);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,RncCedula")] Contribuyente contribuyente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contribuyente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contribuyente);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contribuyente = await _context.Contribuyentes.FindAsync(id);
            if (contribuyente == null) return NotFound();

            return View(contribuyente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,RncCedula")] Contribuyente contribuyente)
        {
            if (id != contribuyente.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contribuyente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Contribuyentes.Any(e => e.Id == contribuyente.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contribuyente);
        }

        

public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var contribuyente = await _context.Contribuyentes
        .FirstOrDefaultAsync(m => m.Id == id);
    if (contribuyente == null)
    {
        return NotFound();
    }

    return View(contribuyente);
}


[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var contribuyente = await _context.Contribuyentes.FindAsync(id);
    if (contribuyente != null)
    {
        _context.Contribuyentes.Remove(contribuyente);
        await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
}
    }
}
