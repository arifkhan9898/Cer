using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class EquipmentItem : BaseEntity
    {
        public virtual ICollection<RentEquipmentItem> RentEquipmentItems { get; set; }
        public int ItemType { get; set; }
        public string ItemName { get; set; }
    }
}