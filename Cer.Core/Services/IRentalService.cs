using System.Collections.Generic;
using Cer.Core.DataTransferObjects;
using Cer.Core.Models;

namespace Cer.Core.Services
{
    public interface IRentalService
    {
        IEnumerable<EquipmentItem> GetAvailableEquipmentItems();
        RentCart SubmitOrder(int[] ids);
        InvoiceDto GetInvoice(RentCart rentCart);
    }
}
