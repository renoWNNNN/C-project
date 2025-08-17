namespace inkTHINK.Application.DTOs;

public class CalculoRequestDto
{
    public int? ContribuyenteId { get; set; }
    public string Tipo { get; set; } = string.Empty; 
    public double Ingresos { get; set; }
    public double Gastos { get; set; }
    public double BaseITBIS { get; set; }
}