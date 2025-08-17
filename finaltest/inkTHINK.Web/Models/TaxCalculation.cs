namespace inkTHINK.Web.Models
{
    public class TaxCalculation
    {
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount => Amount * TaxRate / 100;
        public decimal Total => Amount + TaxAmount;

        public virtual string Description => "Cálculo de impuesto genérico";
    }
}
