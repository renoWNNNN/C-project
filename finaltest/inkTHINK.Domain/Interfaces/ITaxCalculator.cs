using inkTHINK.Domain.Entities.Abstracciones;
using inkTHINK.Domain.ValueObjects;

namespace inkTHINK.Domain.Interfaces;

public interface ITaxCalculator
{
    Entities.Abstracciones.TaxResult Calcular(Tax tax, TaxInput input);
}