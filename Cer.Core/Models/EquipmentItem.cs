using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class EquipmentItem : IIdentifiableEntity<int>
    {
        public int EquipmentItemId { get; set; }
        public virtual ICollection<RentEquipmentItem> RentEquipmentItems { get; set; }
        public int ItemType { get; set; }
        public string ItemName { get; set; }
        // shadow property timestamp

        public int EntityId
        {
            get { return EquipmentItemId; }
            set { EquipmentItemId = value; }
        }
    }
}