using System;

namespace Cer.Service.Logics
{
    public class SpecializedPriceCalculatorLogic : PriceCalculatorLogic
    {
        public override decimal GetPriceInEuros(int days)
        {
            return Math.Min(3, days) * PremiumDailyFeeInEuros + (days > 3 ? (days - 3) * RegularDailyFeeInEuros : 0);
        }
    }
}