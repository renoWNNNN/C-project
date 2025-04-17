using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAKLY.Datos;
using SPAKLY.Modelos;

namespace SPAKLY.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly SPAKLYDbContext _context;

        public ProductoController(SPAKLYDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Productos>> CrearProducto(Productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductos), new { id = producto.ProductosId }, producto);
        }
    }
}
