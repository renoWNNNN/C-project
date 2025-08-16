using inkTHINK.Application.DTOs;
using inkTHINK.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace inkTHINK.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculoController : ControllerBase
{
    private readonly CalculoService _service;
    public CalculoController(CalculoService service) => _service = service;

    [HttpPost("itbis")]
    public async Task<ActionResult<CalculoResponseDto>> ITBIS([FromBody] CalculoRequestDto req)
    {
        req.Tipo = "ITBIS";
        return await _service.CalcularAsync(req);
    }

    [HttpPost("isr")]
    public async Task<ActionResult<CalculoResponseDto>> ISR([FromBody] CalculoRequestDto req)
    {
        req.Tipo = "ISR";
        return await _service.CalcularAsync(req);
    }
}