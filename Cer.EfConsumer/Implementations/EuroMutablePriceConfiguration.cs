using Cer.Service.Interfaces;

namespace Cer.Service.Implementations
{
    public class EuroMutablePriceConfiguration : IMutablePriceConfiguration
    {
        protected EuroMutablePriceConfiguration(decimal oneTimeRentalFee = 100, decimal premiumDailyFee = 60, decimal regularDailyFee = 40)
        {
            OneTimeRentalFee = oneTimeRentalFee;
            PremiumDailyFee = premiumDailyFee;
            RegularDailyFee = regularDailyFee;
        }

        public decimal OneTimeRentalFee { get; set; }
        public decimal PremiumDailyFee { get; set; }
        public decimal RegularDailyFee { get; set; }
    }
}