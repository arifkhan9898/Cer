using System;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentEquipmentItem : BaseEntity
    {
        public int RentItemId { get; set; }
        public int EquipmentItemId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public virtual RentState RentState { get; set; }
        public virtual RentCart RentCart { get; set; }
        public virtual EquipmentItem EquipmentItem { get; set; }
    }
}