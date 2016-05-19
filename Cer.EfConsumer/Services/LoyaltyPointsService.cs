using System.Collections.Generic;
using System.Linq;
using Cer.Core.Enum;
using Cer.Service.Interfaces;

namespace Cer.Service.Services
{
    public class LoyaltyPointsService : ILoyaltyPointsService
    {
        public decimal GetLoyaltyPoints(IEnumerable<EquipmentType> equipmentTypes)
        {
            var multimap = equipmentTypes.ToLookup(o => o);

            return multimap[EquipmentType.Heavy].Count() * 2 +
                   multimap[EquipmentType.Regular].Count() +
                   multimap[EquipmentType.Specialized].Count();
        }
    }
}