namespace inkTHINK.Domain.Entities;

public class Contribuyente
{
    public int Id { get; set; }
    public string NombreComercial { get; set; } = string.Empty;
    public string Tipo { get; set; } = "PERSONA_FISICA";
    public string Regimen { get; set; } = "GENERAL";
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
}