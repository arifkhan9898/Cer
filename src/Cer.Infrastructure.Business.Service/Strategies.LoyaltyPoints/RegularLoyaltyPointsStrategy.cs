using Cer.Infrastructure.Business.Service.Interfaces;

namespace Cer.Infrastructure.Business.Service.Strategies.LoyaltyPoints
{
    public class RegularLoyaltyPointsStrategy : ILoyaltyPointsStrategy
    {
        public decimal GetLoyaltyPoints(int heavyCount, int regularCount, int specializedCount)
        {
            return heavyCount * 2 + regularCount + specializedCount;
        }
    }
}