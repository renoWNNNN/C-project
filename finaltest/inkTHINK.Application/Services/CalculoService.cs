using System.Text.Json;
using inkTHINK.Application.DTOs;
using inkTHINK.Application.Mapping;
using inkTHINK.Domain.Entities;
using inkTHINK.Domain.Entities.Abstracciones;
using inkTHINK.Domain.Interfaces;

namespace inkTHINK.Application.Services;

public class CalculoService
{
    private readonly IUnitOfWork _uow;
    private readonly IRuleProvider _rules;

    public CalculoService(IUnitOfWork uow, IRuleProvider rules)
    {
        _uow = uow;
        _rules = rules;
    }

    public async Task<CalculoResponseDto> CalcularAsync(CalculoRequestDto req)
    {
        var reglasJson = _rules.GetParamsJson(req.Tipo);
        using var doc = JsonDocument.Parse(reglasJson);
        var root = doc.RootElement;

        Tax tax = req.Tipo.ToUpper() switch
        {
            "ITBIS" => new ITBIS(root.GetProperty("tasa").GetDouble()),
            "ISR" => new ISR(
                root.GetProperty("tramos").EnumerateArray()
                    .Select(x => (x[0].GetDouble(), x[1].GetDouble())).ToArray(),
                root.TryGetProperty("deduccionBasica", out var d) ? d.GetDouble() : 0
            ),
            _ => throw new InvalidOperationException("Tipo de impuesto no soportado")
        };

        var input = new TaxInput
        {
            Ingresos = req.Ingresos,
            Gastos = req.Gastos,
            BaseITBIS = req.BaseITBIS
        };

        var result = tax.Calcular(input);
        var valueObjectResult = new Domain.ValueObjects.TaxResult
        {
            Monto = result.Monto
            
        };
        var dto = SimpleMapper.Map(valueObjectResult, reglasJson);

        var calc = new Calculo
        {
            ContribuyenteId = req.ContribuyenteId,
            Fecha = DateTime.UtcNow,
            Tipo = req.Tipo,
            RequestSnapshot = JsonSerializer.Serialize(req),
            ResultSnapshot = JsonSerializer.Serialize(dto),
            ReglasVersionadas = reglasJson
        };
        await _uow.Calculos.AddAsync(calc);
        await _uow.SaveChangesAsync();

        return dto;
    }
}