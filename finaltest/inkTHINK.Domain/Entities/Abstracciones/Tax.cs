namespace inkTHINK.Domain.Entities.Abstracciones;

public abstract class Tax
{
    public abstract string Nombre { get; }
    public abstract TaxResult Calcular(TaxInput input);
    public virtual string Explicar() => "";
}

public class TaxResult
{
    public double Monto { get; internal set; }
    public object? Desglose { get; internal set; }
    public string? Explicacion { get; internal set; }
    public required object Detalle { get; set; }
}

public class TaxInput
{
    public double Ingresos { get; set; }
    public double Gastos { get; set; }
    public double BaseITBIS { get; set; }
    public double? DeduccionBasica { get; set; }
    public Dictionary<string, object> Parametros { get; set; } = new();
}