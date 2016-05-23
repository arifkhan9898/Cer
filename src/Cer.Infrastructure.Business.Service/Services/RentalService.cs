using System;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Interfaces.Services;

namespace Cer.Infrastructure.Business.Service.Services
{
    public class RentalService : IRentalService
    {
        private readonly IQueryHandler<PagingDto, EquipmentViewDto> _equipmentViewDtoQueryHandler;
        private readonly IQueryHandler<CartDto, InvoiceDto> _invoiceDtoQueryHandler;
        private readonly IQueryHandler<EquipmentRentRequestDto, CartDto> _cartDtoQueryHandler;

        public RentalService(
            IQueryHandler<PagingDto, EquipmentViewDto> equipmentViewDtoQueryHandler,
            IQueryHandler<CartDto, InvoiceDto> invoiceDtoQueryHandler,
            IQueryHandler<EquipmentRentRequestDto, CartDto> cartDtoQueryHandler)
        {
            if (equipmentViewDtoQueryHandler == null)
                throw new ArgumentNullException(nameof(equipmentViewDtoQueryHandler));
            if (invoiceDtoQueryHandler == null)
                throw new ArgumentNullException(nameof(invoiceDtoQueryHandler));
            if (cartDtoQueryHandler == null)
                throw new ArgumentNullException(nameof(cartDtoQueryHandler));

            _equipmentViewDtoQueryHandler = equipmentViewDtoQueryHandler;
            _invoiceDtoQueryHandler = invoiceDtoQueryHandler;
            _cartDtoQueryHandler = cartDtoQueryHandler;
        }

        public EquipmentViewDto GetAvailableEquipmentWithPaging(PagingDto page)
        {
            return _equipmentViewDtoQueryHandler.Handle(page);
        }

        public CartDto SubmitRentRequest(EquipmentRentRequestDto equipmentRentRequestDto)
        {
            return _cartDtoQueryHandler.Handle(equipmentRentRequestDto);
        }

        public InvoiceDto GetInvoice(CartDto cart)
        {
            return _invoiceDtoQueryHandler.Handle(cart);
        }
    }
}