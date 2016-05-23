using Cer.Core.Dtos;

namespace Cer.Core.Interfaces.Services
{
    public interface IRentalService
    {
        EquipmentViewDto GetAvailableEquipmentWithPaging(PagingDto page);
        CartDto SubmitRentRequest(EquipmentRentRequestDto equipmentRentRequestDto);
        InvoiceDto GetInvoice(CartDto cart);
    }
}