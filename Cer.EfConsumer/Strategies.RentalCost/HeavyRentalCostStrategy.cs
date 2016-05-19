using Cer.Service.Interfaces;

namespace Cer.Service.Strategies.RentalCost
{
    /// <summary>
    /// Heavy – rental price is one-time rental fee plus premium fee for each day rented.
    /// Regular – rental price is one-time rental fee plus premium fee for the first 2 days plus regular fee for the number of days over 2.
    /// Specialized – rental price is premium fee for the first 3 days plus regular fee times the number of days over 3.
    /// </summary>
    public class HeavyRentalCostStrategy : IRentalCostStrategy
    {
        private readonly IMutablePriceConfiguration _prices;

        public HeavyRentalCostStrategy(IMutablePriceConfiguration prices)
        {
            _prices = prices;
        }

        public decimal Calculate(int days)
        {
            return _prices.OneTimeRentalFee + _prices.PremiumDailyFee * days;
        }
    }
}