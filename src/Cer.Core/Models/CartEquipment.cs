using System;
using System.ComponentModel.DataAnnotations;
using Cer.Core.Abstractions;
using Cer.Core.Enum;
using Cer.Core.Interfaces.Models;

namespace Cer.Core.Models
{
    public class CartEquipment : BaseEntity, ICartEquipment
    {
        public int CartId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime? ReturnDate { get; set; }
        [EnumDataType(typeof(RentState))]
        public virtual RentState RentState { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int RentDurationDays { get; set; }

        public int RentStateId
        {
            get
            {
                return (int)RentState;
            }
            set
            {
                RentState = (RentState)value;
            }
        }
    }
}