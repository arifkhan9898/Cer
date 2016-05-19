using System;
using System.Collections.Generic;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Service.Interfaces;
using Cer.Service.Strategies.RentalCost;

namespace Cer.Service.Maps
{
    public class MapRentalCostStrategy : IMapper<EquipmentType, IRentalCostStrategy>
    {
        private readonly Dictionary<EquipmentType, IRentalCostStrategy> _knownRentalCostStrategy;

        public MapRentalCostStrategy(IMutablePriceConfiguration mutablePriceConfiguration)
        {
            _knownRentalCostStrategy = new Dictionary<EquipmentType, IRentalCostStrategy>
            {
                { EquipmentType.Heavy, new HeavyRentalCostStrategy(mutablePriceConfiguration)},
                { EquipmentType.Specialized, new SpecializedRentalCostStrategy(mutablePriceConfiguration)},
                { EquipmentType.Regular, new RegularRentalCostStrategy(mutablePriceConfiguration)}
            };
        }

        public Func<EquipmentType, IRentalCostStrategy> Create => equipment =>
        {
            if (!_knownRentalCostStrategy.ContainsKey(equipment))
                throw new ArgumentException();

            return _knownRentalCostStrategy[equipment];
        };
    }
}