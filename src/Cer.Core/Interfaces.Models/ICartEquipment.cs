using System;
using Cer.Core.Enum;
using Cer.Core.Models;

namespace Cer.Core.Interfaces.Models
{
    public interface ICartEquipment
    {
        Equipment Equipment { get; set; }
        Cart Cart { get; set; }
        RentState RentState { get; set; }
        DateTime? ReturnDate { get; set; }
        int RentDurationDays { get; set; }
    }
}