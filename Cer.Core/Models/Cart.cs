using System.Collections.Generic;
using Cer.Core.Abstractions;
using Cer.Core.Interfaces.Models;

namespace Cer.Core.Models
{
    public class Cart : BaseEntity, ICart
    {
        public virtual int UserId { get; set; }
        public virtual ICollection<CartEquipment> CartEquipments { get; set; }
        public virtual User User { get; set; }
        public int RentDurationDays { get; set; }
    }
}