namespace inkTHINK.Web.Controllers
{
    public class CalculosController : Controller
    {
        private readonly AppDbContext _context;

        public CalculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var calculos = await _context.Calculos
                .Include(c => c.Contribuyente)
                .ToListAsync();

            ViewBag.Contribuyentes = await _context.Contribuyentes.ToListAsync();
            ViewBag.TaxRules = await _context.TaxRules
                .Where(r => r.VigenteHasta == null || r.VigenteHasta > DateTime.UtcNow)
                .ToListAsync();

            return View(calculos);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int contribuyenteId, decimal monto, int[] reglasSeleccionadas)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(contribuyenteId);
            if (contribuyente == null)
            {
                ModelState.AddModelError("", "Contribuyente no válido.");
                return RedirectToAction(nameof(Index));
            }

            if (reglasSeleccionadas == null || reglasSeleccionadas.Length == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos una regla tributaria.");
                return RedirectToAction(nameof(Index));
            }

            var taxRules = await _context.TaxRules
                .Where(r => reglasSeleccionadas.Contains(r.Id))
                .ToListAsync();

            var detalle = new Dictionary<string, decimal>();
            decimal totalImpuesto = 0;

            foreach (var rule in taxRules)
            {
                var impuesto = monto * rule.Porcentaje / 100;
                detalle[rule.Nombre] = impuesto;
                totalImpuesto += impuesto;
            }

            var calculo = new Calculo
            {
                ContribuyenteId = contribuyenteId,
                Monto = monto,
                ImpuestoCalculado = totalImpuesto,
                Fecha = DateTime.Now,
                DetalleImpuestosJson = JsonSerializer.Serialize(detalle)
            };

            _context.Calculos.Add(calculo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var calculo = await _context.Calculos.FindAsync(id);
            if (calculo == null) return NotFound();

            ViewBag.Contribuyentes = await _context.Contribuyentes.ToListAsync();
            ViewBag.TaxRules = await _context.TaxRules
                .Where(r => r.VigenteHasta == null || r.VigenteHasta > DateTime.UtcNow)
                .ToListAsync();

            return View(calculo);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int contribuyenteId, decimal monto, int[] reglasSeleccionadas)
        {
            var calculo = await _context.Calculos.FindAsync(id);
            if (calculo == null) return NotFound();

            var contribuyente = await _context.Contribuyentes.FindAsync(contribuyenteId);
            if (contribuyente == null)
            {
                ModelState.AddModelError("", "Contribuyente no válido.");
                return RedirectToAction(nameof(Index));
            }

            var taxRules = await _context.TaxRules
                .Where(r => reglasSeleccionadas.Contains(r.Id))
                .ToListAsync();

            var detalle = new Dictionary<string, decimal>();
            decimal totalImpuesto = 0;
            foreach (var rule in taxRules)
            {
                var impuesto = monto * rule.Porcentaje / 100;
                detalle[rule.Nombre] = impuesto;
                totalImpuesto += impuesto;
            }

            calculo.ContribuyenteId = contribuyenteId;
            calculo.Monto = monto;
            calculo.ImpuestoCalculado = totalImpuesto;
            calculo.DetalleImpuestosJson = JsonSerializer.Serialize(detalle);
            calculo.Fecha = DateTime.Now;

            _context.Calculos.Update(calculo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var calculo = await _context.Calculos.FindAsync(id);
            if (calculo == null) return NotFound();

            _context.Calculos.Remove(calculo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
