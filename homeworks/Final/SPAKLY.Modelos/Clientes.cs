using System.ComponentModel.DataAnnotations;

namespace SPAKLY.Modelos
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
    }
}