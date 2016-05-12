using System;
using Cer.Core.Abstractions;

namespace Cer.Core.Models
{
    public class RentEquipmentItem : IIdentifiableEntity<int>
    {
        public int RentEquipmentItemId { get; set; }
        public int RentItemId { get; set; }
        public int EquipmentItemId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentStateLastUpdate { get; set; }
        public RentState RentState { get; set; }
        public virtual RentItem RentItem { get; set; }
        public virtual EquipmentItem EquipmentItem { get; set; }
        public int EntityId
        {
            get { return RentEquipmentItemId; }
            set { RentEquipmentItemId = value; }
        }
    }
}