namespace inkTHINK.Domain.Entities;

public class TaxRule
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty; 
    public string Version { get; set; } = "v1";
    public string ParamsJson { get; set; } = "{}"; 
    public DateTime VigenteDesde { get; set; } = DateTime.UtcNow.Date;
    public DateTime? VigenteHasta { get; set; }
}