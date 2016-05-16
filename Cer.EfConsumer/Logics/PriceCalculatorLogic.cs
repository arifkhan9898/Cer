namespace Cer.Service.Logics
{
    public abstract class PriceCalculatorLogic : IPriceCalculatorLogic
    {
        protected PriceCalculatorLogic(decimal oneTimeRentalFeeInEuros = 100, decimal premiumDailyFeeInEuros = 60, decimal regularDailyFeeInEuros = 40)
        {
            OneTimeRentalFeeInEuros = oneTimeRentalFeeInEuros;
            PremiumDailyFeeInEuros = premiumDailyFeeInEuros;
            RegularDailyFeeInEuros = regularDailyFeeInEuros;
        }

        public abstract decimal GetPriceInEuros(int days);

        public decimal OneTimeRentalFeeInEuros { get; }
        public decimal PremiumDailyFeeInEuros { get; }
        public decimal RegularDailyFeeInEuros { get; }
    }
}