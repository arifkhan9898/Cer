using System;
using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentCart : BaseEntity
    {
        public string CustomerNickname { get; set; }
        public virtual ICollection<RentEquipmentItem> RentEquipmentItems { get; set; }
        public int RentDurationDays { get; set; }
    }
}