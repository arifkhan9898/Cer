using System.Collections.Generic;
using Cer.Core.Enum;

namespace Cer.Infrastructure.Business.Service.Interfaces
{
    public interface ILoyaltyPointsProvider
    {
        decimal GetLoyaltyPoints(IEnumerable<EquipmentType> equipmentTypes);
    }
}