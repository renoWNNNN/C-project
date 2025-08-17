namespace inkTHINK.Domain.Entities;

public class Calculo
{
    public int Id { get; set; }
    public int? ContribuyenteId { get; set; }
    public Contribuyente? Contribuyente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public string Tipo { get; set; } = string.Empty;
    public string RequestSnapshot { get; set; } = "{}";
    public string ResultSnapshot { get; set; } = "{}";
    public string ReglasVersionadas { get; set; } = "{}";
    public decimal Monto { get; set; }
    public decimal ImpuestoCalculado { get; set; }

    public string DetalleImpuestosJson { get; set; } = "{}";
}