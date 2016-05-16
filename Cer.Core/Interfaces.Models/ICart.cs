using Cer.Core.Models;

namespace Cer.Core.Interfaces.Models
{
    public interface ICart
    {
        int RentDurationDays { get; set; }
        User User { get; set; }
    }
}