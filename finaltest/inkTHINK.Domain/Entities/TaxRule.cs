namespace inkTHINK.Domain.Entities;

public class TaxRule
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public decimal Porcentaje { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public string Tipo { get; set; } = string.Empty;

    public string Version { get; set; } = "v1";

    public string ParamsJson { get; set; } = "{}";

    public DateTime VigenteDesde { get; set; } = DateTime.Now;

    public DateTime? VigenteHasta { get; set; }
}
