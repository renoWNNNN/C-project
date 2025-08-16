using inkTHINK.Domain.Entities;
using inkTHINK.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inkTHINK.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContribuyentesController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    public ContribuyentesController(IUnitOfWork uow) => _uow = uow;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contribuyente>>> Get() => Ok(await _uow.Contribuyentes.GetAllAsync());

    [HttpPost]
    public async Task<ActionResult<Contribuyente>> Post(Contribuyente c)
    {
        await _uow.Contribuyentes.AddAsync(c);
        await _uow.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = c.Id }, c);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contribuyente>> GetById(int id)
    {
        var c = await _uow.Contribuyentes.GetByIdAsync(id);
        return c is null ? NotFound() : Ok(c);
    }
}