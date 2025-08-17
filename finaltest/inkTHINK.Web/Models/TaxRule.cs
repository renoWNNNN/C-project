namespace inkTHINK.Web.Models
{
    public class TaxRule
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Porcentaje { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;
    }
}
