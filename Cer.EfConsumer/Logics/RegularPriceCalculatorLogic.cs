using System;

namespace Cer.Service.Logics
{
    public class RegularPriceCalculatorLogic : PriceCalculatorLogic
    {
        public override decimal GetPriceInEuros(int days)
        {
            return OneTimeRentalFeeInEuros + Math.Min(2, days) * PremiumDailyFeeInEuros + (days > 2 ? (days - 2) * RegularDailyFeeInEuros : 0);
        }
    }
}