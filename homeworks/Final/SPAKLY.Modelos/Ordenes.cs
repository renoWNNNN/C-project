using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SPAKLY.Modelos
{
    public class Ordenes
    {
        [Key]
        public int IdPedido { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int ClienteId { get; set; }

        public Clientes? Cliente { get; set; }

    }
}
