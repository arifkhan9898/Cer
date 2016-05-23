using System.Collections.Generic;
using Cer.Core.Abstractions;
using Cer.Core.Enum;
using Cer.Core.Interfaces.Models;

namespace Cer.Core.Models
{
    public class Equipment : BaseEntity, IEquipment
    {
        public virtual ICollection<CartEquipment> CartEquipments { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public int EquipmentAmountId { get; set; }
        public virtual EquipmentAmount EquipmentAmount { get; set; }
        public int EquipmentTypeId
        {
            get
            {
                return (int)EquipmentType;
            }
            set
            {
                EquipmentType = (EquipmentType)value;
            }
        }
    }
}