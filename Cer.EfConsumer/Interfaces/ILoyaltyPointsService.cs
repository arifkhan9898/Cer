using System.Collections.Generic;
using Cer.Core.Enum;

namespace Cer.Service.Interfaces
{
    public interface ILoyaltyPointsService
    {
        decimal GetLoyaltyPoints(IEnumerable<EquipmentType> equipmentTypes);
    }
}