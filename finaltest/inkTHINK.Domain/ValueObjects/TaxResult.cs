namespace inkTHINK.Domain.ValueObjects;

public class TaxResult
{
    public double Monto { get; set; }
    public string Explicacion { get; set; } = string.Empty;
    public Dictionary<string, double> Desglose { get; set; } = new();
    public object? Detalle { get; set; }
}