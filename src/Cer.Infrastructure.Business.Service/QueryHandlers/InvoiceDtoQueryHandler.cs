using System;
using System.Linq;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.Interfaces;
using Cer.Infrastructure.Business.Service.Specifications;

namespace Cer.Infrastructure.Business.Service.QueryHandlers
{
    public class InvoiceDtoQueryHandler : IQueryHandler<CartDto, InvoiceDto>
    {
        private readonly IRepository<CartEquipment> _cartEquipments;
        private readonly ILoyaltyPointsProvider _loyaltyPointsProvider;
        private readonly IMapper<EquipmentType, IRentalCostStrategy> _mapPriceCalculatorLogic;
        private readonly IMutablePriceConfiguration _mutablePriceConfiguration;

        public InvoiceDtoQueryHandler(
            IRepository<CartEquipment> cartEquipments,
            ILoyaltyPointsProvider loyaltyPointsProvider,
            IMapper<EquipmentType, IRentalCostStrategy> mapPriceCalculatorLogic,
            IMutablePriceConfiguration mutablePriceConfiguration)
        {
            if (cartEquipments == null)
                throw new ArgumentNullException(nameof(cartEquipments));
            if (loyaltyPointsProvider == null)
                throw new ArgumentNullException(nameof(loyaltyPointsProvider));
            if (mapPriceCalculatorLogic == null)
                throw new ArgumentNullException(nameof(mapPriceCalculatorLogic));
            if (mutablePriceConfiguration == null)
                throw new ArgumentNullException(nameof(mutablePriceConfiguration));

            _cartEquipments = cartEquipments;
            _loyaltyPointsProvider = loyaltyPointsProvider;
            _mapPriceCalculatorLogic = mapPriceCalculatorLogic;
            _mutablePriceConfiguration = mutablePriceConfiguration;
        }

        public InvoiceDto Handle(CartDto cartDto)
        {
            if (cartDto == null)
                throw new ArgumentNullException(nameof(cartDto));

            // Todo : think about if this is poorly written code (nor real unit test)
            // Todo : need to make specification provider
            var predicate = new CartEquipmentByCartIdSpecification(cartDto.CartId);

            // Todo : think if filter need sort order and if max 25 items is reasonable. 
            var cartequipments = _cartEquipments.Filter(o => o.Equipment, predicate, page: 0);
            if (cartequipments == null)
                throw new ArgumentNullException(nameof(cartDto));

            var cartEquipmentTypes = cartequipments.Select(o => o.Equipment.EquipmentType);
            var loyaltyPoints = _loyaltyPointsProvider.GetLoyaltyPoints(cartEquipmentTypes);
            var rentalDtos = cartequipments.Select(MapCartEquipment).ToList();
            var totalPrice = rentalDtos.Sum(o => o.Price);
            var invoiceDto = new InvoiceDto
            {
                Title = $"Invoice id : {cartDto.CartId}",
                Rentals = rentalDtos,
                LoyaltyPoints = loyaltyPoints,
                TotalPrice = totalPrice
            };

            return invoiceDto;
        }

        // Todo : think if mapper is doing too much
        private RentalDto MapCartEquipment(CartEquipment cartEquipment)
        {
            var price = _mapPriceCalculatorLogic
                .Create(cartEquipment.Equipment.EquipmentType)
                .Calculate(cartEquipment.RentDurationDays, _mutablePriceConfiguration);

            return new RentalDto
            {
                Name = cartEquipment.Equipment.EquipmentName,
                Price = price
            };
        }
    }
}