using Cer.Core.Abstractions;
using Cer.Core.Interfaces.Models;

namespace Cer.Core.Models
{
    public class EquipmentAmount : BaseEntity, IEquipmentAmount
    {
        public decimal Amount { get; set; }
    }
}