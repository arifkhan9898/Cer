using System;
using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentItem : IIdentifiableEntity<int>
    {
        public int RentItemId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<RentEquipmentItem> RentEquipmentItems { get; set; }
        public int RentDurationDays { get; set; }
        public DateTime RentDateAdded { get; set; }

        public int EntityId
        {
            get { return RentItemId; }
            set { RentItemId = value; }
        }
    }
}