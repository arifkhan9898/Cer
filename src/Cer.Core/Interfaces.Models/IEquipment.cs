using Cer.Core.Enum;
using Cer.Core.Models;

namespace Cer.Core.Interfaces.Models
{
    public interface IEquipment : IIdentifiable
    {
        string EquipmentName { get; set; }
        EquipmentType EquipmentType { get; set; }
        EquipmentAmount EquipmentAmount { get; set; }
    }
}