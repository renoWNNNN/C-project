namespace inkTHINK.Web.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public int ContribuyenteId { get; set; }
        public decimal Monto { get; set; }
        public decimal ImpuestoCalculado { get; set; }

        public Contribuyente? Contribuyente { get; set; }
    }
}
