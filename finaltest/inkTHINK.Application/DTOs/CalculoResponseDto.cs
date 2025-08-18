using System.Text.Json.Serialization;

namespace inkTHINK.Application.DTOs;

public class CalculoResponseDto
{
    public double Monto { get; set; }
    public string Explicacion { get; set; } = string.Empty;
    public Dictionary<string, double> Desglose { get; set; } = new();
    [JsonIgnore]
    public string ReglasUsadasJson { get; set; } = "{}";
}