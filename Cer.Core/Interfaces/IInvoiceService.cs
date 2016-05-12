using Cer.Core.DataTransferObjects;

namespace Cer.Core.Interfaces
{
    public interface IInvoiceService
    {
        InvoiceDto GetInvoice(int rentItemId);
    }
}