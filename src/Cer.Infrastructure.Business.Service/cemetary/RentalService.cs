//using System;
//using Cer.Core.Dtos;
//using Cer.Core.Interfaces.Services;
//using Cer.Infrastructure.Business.Service.Interfaces;

//namespace Cer.Infrastructure.Business.Service.cemetary
//{
//    public class RentalService : IRentalService
//    {
//        private readonly IEquipmentViewDtoProvider _equipmentViewDtoProvider;
//        private readonly IInvoiceDtoProvider _invoiceDtoProvider;
//        private readonly ICartDtoProvider _cartDtoProvider;

//        public RentalService(
//            IEquipmentViewDtoProvider equipmentViewDtoProvider,
//            IInvoiceDtoProvider invoiceDtoProvider,
//            ICartDtoProvider cartDtoProvider)
//        {
//            if (equipmentViewDtoProvider == null)
//                throw new ArgumentNullException(nameof(equipmentViewDtoProvider));
//            if (invoiceDtoProvider == null)
//                throw new ArgumentNullException(nameof(invoiceDtoProvider));
//            if (cartDtoProvider == null)
//                throw new ArgumentNullException(nameof(cartDtoProvider));

//            _equipmentViewDtoProvider = equipmentViewDtoProvider;
//            _invoiceDtoProvider = invoiceDtoProvider;
//            _cartDtoProvider = cartDtoProvider;
//        }

//        public EquipmentViewDto GetAvailableEquipmentWithPaging(int page = 0)
//        {
//            return _equipmentViewDtoProvider.GetAvailableEquipmentWithPaging(page);
//        }

//        public EquipmentViewDto GetAvailableEquipmentWithPaging(PagingDto page)
//        {
//            throw new NotImplementedException();
//        }

//        public CartDto SubmitRentRequest(EquipmentRentRequestDto equipmentRentRequestDto)
//        {
//            return _cartDtoProvider.SubmitRentRequest(equipmentRentRequestDto);
//        }

//        public InvoiceDto GetInvoice(CartDto cart)
//        {
//            return _invoiceDtoProvider.GetInvoice(cart);
//        }
//    }
//}