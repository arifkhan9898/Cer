using System.Collections.Generic;
using Cer.Core.Enum;

namespace Cer.Infrastructure.Business.Service.Interfaces
{
    public interface IRentalCostStrategyProvider
    {
        IDictionary<EquipmentType, IRentalCostStrategy> Strategies { get; }
    }
}