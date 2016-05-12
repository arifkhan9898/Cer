using System.Collections.Generic;
using Cer.Core.Models;

namespace Cer.Core.Interfaces
{
    public interface IRentItemService
    {
        IEnumerable<RentItem> GetAvailableRentItems();
    }
}