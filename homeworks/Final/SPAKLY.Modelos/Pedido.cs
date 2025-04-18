using System;
using System.Collections.Generic;
using SPAKLY.Modelos;

namespace SPAKLY.API.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteID { get; set; }
        public Cliente? Cliente { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}
