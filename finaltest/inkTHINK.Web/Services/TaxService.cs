namespace inkTHINK.Web.Models
{
    public interface ITaxService
    {
        ITBISCalculation CalculateITBIS(decimal amount, decimal rate = 18);
        IncomeTaxCalculation CalculateIncomeTax(decimal amount, decimal rate = 10);
    }

    public class TaxService : ITaxService
    {
        public ITBISCalculation CalculateITBIS(decimal amount, decimal rate = 18)
            => new ITBISCalculation { Amount = amount, TaxRate = rate };

        public IncomeTaxCalculation CalculateIncomeTax(decimal amount, decimal rate = 10)
            => new IncomeTaxCalculation { Amount = amount, TaxRate = rate };
    }
}
