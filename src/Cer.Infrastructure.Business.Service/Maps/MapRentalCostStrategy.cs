using System;
using System.Collections.Generic;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Infrastructure.Business.Service.Interfaces;

namespace Cer.Infrastructure.Business.Service.Maps
{
    public class MapRentalCostStrategy : IMapper<EquipmentType, IRentalCostStrategy>
    {
        private readonly IDictionary<EquipmentType, IRentalCostStrategy> _strategies;

        public MapRentalCostStrategy(IRentalCostStrategyProvider rentalCostStrategyProvider)
        {
            if (rentalCostStrategyProvider == null)
                throw new ArgumentNullException(nameof(rentalCostStrategyProvider));
            if (rentalCostStrategyProvider.Strategies == null)
                throw new InvalidOperationException();

            _strategies = rentalCostStrategyProvider.Strategies;
        }

        public Func<EquipmentType, IRentalCostStrategy> Create => equipment =>
        {
            if (!_strategies.ContainsKey(equipment))
                throw new ArgumentException();

            return _strategies[equipment];
        };
    }
}