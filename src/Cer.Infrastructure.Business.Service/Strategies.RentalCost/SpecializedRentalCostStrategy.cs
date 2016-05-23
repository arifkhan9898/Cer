using System;
using Cer.Infrastructure.Business.Service.Interfaces;

namespace Cer.Infrastructure.Business.Service.Strategies.RentalCost
{
    public class SpecializedRentalCostStrategy : IRentalCostStrategy
    {
        public decimal Calculate(int days, IMutablePriceConfiguration prices)
        {
            return Math.Min(3, days) * prices.PremiumDailyFee + (days > 3 ? (days - 3) * prices.RegularDailyFee : 0);
        }
    }
}