using System.Collections.Generic;
using Cer.Core.Enum;

namespace Cer.Service.Logics
{
    public interface ILoyaltyPointsLogic
    {
        decimal GetLoyaltyPoints(IEnumerable<EquipmentType> equipmentTypes);
    }
}