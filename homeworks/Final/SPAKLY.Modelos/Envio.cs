using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SPAKLY.Modelos
{
    public class Envio
    {
        [Key]
        public int EnvioId { get; set; }

        public string? Direccion { get; set; }

        public string? Estado { get; set; }

        public DateTime? FechaEnvio { get; set; }
    }
}
