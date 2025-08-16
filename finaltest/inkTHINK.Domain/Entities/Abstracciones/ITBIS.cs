namespace inkTHINK.Domain.Entities.Abstracciones;

public class ITBIS : Tax
{
    private readonly double _tasa; 
    public ITBIS(double tasa) => _tasa = tasa;
    public override string Nombre => "ITBIS";

    public override TaxResult Calcular(TaxInput input)
    {
        var monto = input.BaseITBIS * _tasa;
        return new TaxResult
        {
            Monto = monto,
            Explicacion = $"ITBIS = Base {input.BaseITBIS} x Tasa {_tasa}",
            Desglose = new Dictionary<string, double> { ["Base"] = input.BaseITBIS, ["Tasa"] = _tasa },
            Detalle = "" 
        };
    }
}