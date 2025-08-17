namespace inkTHINK.Domain.Interfaces;

public interface ITaxCalculator
{
    Entities.Abstracciones.TaxResult Calcular(Tax tax, TaxInput input);
}