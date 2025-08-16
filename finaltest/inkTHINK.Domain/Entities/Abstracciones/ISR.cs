namespace inkTHINK.Domain.Entities.Abstracciones;

public class ISR : Tax
{
    private readonly (double Limite, double Tasa)[] _tramos;
    private readonly double _deduccionBasica;
    public ISR((double Limite, double Tasa)[] tramos, double deduccionBasica = 0)
    {
        _tramos = tramos;
        _deduccionBasica = deduccionBasica;
    }

    public override string Nombre => "ISR";

    public override TaxResult Calcular(TaxInput input)
    {
        double baseGravableAnual = Math.Max(0, input.Ingresos - input.Gastos - (_deduccionBasica + (input.DeduccionBasica ?? 0)));
        double restante = baseGravableAnual;
        double impuesto = 0;
        double anterior = 0;
        var desglose = new Dictionary<string, double>();

        foreach (var tramo in _tramos)
        {
            var rango = Math.Max(0, Math.Min(restante, tramo.Limite - anterior));
            if (rango <= 0) { anterior = tramo.Limite; continue; }
            var aporte = rango * tramo.Tasa;
            impuesto += aporte;
            desglose[$"Hasta {tramo.Limite}"] = aporte;
            restante -= rango;
            anterior = tramo.Limite;
            if (restante <= 0) break;
        }

        return new TaxResult
        {
            Monto = impuesto,
            Explicacion = $"ISR por tramos sobre base {baseGravableAnual}",
            Desglose = desglose,
            Detalle = string.Empty 
        };
    }
}