using System.Collections.Generic;
using System.Linq;
using Cer.Core.Enum;
using Cer.Infrastructure.Business.Service.Interfaces;

namespace Cer.Infrastructure.Business.Service.Providers
{
    public class LoyaltyPointsProvider : ILoyaltyPointsProvider
    {
        private readonly ILoyaltyPointsStrategy _loyaltyPointsStrategy;

        public LoyaltyPointsProvider(ILoyaltyPointsStrategy loyaltyPointsStrategy)
        {
            _loyaltyPointsStrategy = loyaltyPointsStrategy;
        }

        public decimal GetLoyaltyPoints(IEnumerable<EquipmentType> equipmentTypes)
        {
            var multimap = equipmentTypes.ToLookup(o => o);
            var heavyCount = multimap[EquipmentType.Heavy].Count();
            var regularCount = multimap[EquipmentType.Regular].Count();
            var specializedCount = multimap[EquipmentType.Specialized].Count();

            return _loyaltyPointsStrategy.GetLoyaltyPoints(heavyCount, regularCount, specializedCount);
        }
    }
}