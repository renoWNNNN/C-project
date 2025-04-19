using System.ComponentModel.DataAnnotations;

namespace SPAKLY.Modelos
{
    public class Productos
    {
        public int ProductosId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        private int _stock;
        public int Stock
        {
            get => _stock;
            set => _stock = value < 0 ? 0 : value;
        }
    }
}
