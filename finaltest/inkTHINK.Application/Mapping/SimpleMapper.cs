using inkTHINK.Application.DTOs;
using inkTHINK.Domain.ValueObjects;

namespace inkTHINK.Application.Mapping;

public static class SimpleMapper
{
    public static CalculoResponseDto Map(TaxResult src, string reglasJson) => new()
    {
        Monto = src.Monto,
        Explicacion = src.Explicacion,
        Desglose = src.Desglose,
        ReglasUsadasJson = reglasJson
    };
}