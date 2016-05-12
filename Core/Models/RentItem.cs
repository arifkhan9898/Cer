using System;
using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentItem : IIdentifiableEntity<int>
    {
        public int RentItemId { get; set; }
        public Customer Customer { get; set; }
        public List<EquipmentItem> EquipmentItems { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime? Returned { get; set; }
        public int RentDurationDays { get; set; }
        public DateTime RentDateAdded { get; set; }
        // shadow property timestamp

        public int EntityId
        {
            get { return RentItemId; }
            set { RentItemId = value; }
        }
    }
}