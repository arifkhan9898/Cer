using System.Collections.Generic;
using Cer.Core.Enum;
using Cer.Infrastructure.Business.Service.Interfaces;
using Cer.Infrastructure.Business.Service.Strategies.RentalCost;

namespace Cer.Infrastructure.Business.Service.Providers
{
    public class RentalCostStrategyProvider : IRentalCostStrategyProvider
    {
        public IDictionary<EquipmentType, IRentalCostStrategy> Strategies =>
            new Dictionary<EquipmentType, IRentalCostStrategy>
            {
                [EquipmentType.Heavy] = new HeavyRentalCostStrategy(),
                [EquipmentType.Regular] = new RegularRentalCostStrategy(),
                [EquipmentType.Specialized] = new SpecializedRentalCostStrategy()
            };
    }
}