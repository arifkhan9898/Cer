using System;
using System.Collections.Generic;
using System.Linq;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Interfaces.Services;
using Cer.Core.Models;
using Cer.Infrastructure.Interfaces;
using Cer.Service.Interfaces;

namespace Cer.Service.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Cart> _carts;
        private readonly IWriteDbContext _writeDbContext;
        private readonly IRepository<Equipment> _equipments;
        private readonly IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILoyaltyPointsService _loyaltyPointsService;
        private readonly IMapper<EquipmentType, IRentalCostStrategy> _mapPriceCalculatorLogic;
        private readonly IEquipmentAvailabilitySpecification _equipmentAvailabilitySpecification;

        public RentalService(
            IRepository<Cart> carts,
            IWriteDbContext writeDbContext,
            IRepository<Equipment> equipments,
            IMapper<Equipment, EquipmentDto> mapEquipment,
            IDateTimeProvider dateTimeProvider,
            ILoyaltyPointsService loyaltyPointsService,
            IMapper<EquipmentType, IRentalCostStrategy> mapPriceCalculatorLogic,
            IEquipmentAvailabilitySpecification equipmentAvailabilitySpecification)
        {
            _carts = carts;
            _writeDbContext = writeDbContext;
            _equipments = equipments;
            _mapEquipmentDto = mapEquipment;
            _dateTimeProvider = dateTimeProvider;
            _loyaltyPointsService = loyaltyPointsService;
            _mapPriceCalculatorLogic = mapPriceCalculatorLogic;
            _equipmentAvailabilitySpecification = equipmentAvailabilitySpecification;
        }

        public EquipmentViewDto GetAvailableEquipmentWithPaging(int skip, int take)
        {
            var availableEquipmentCount = _equipments.Total(_equipmentAvailabilitySpecification);   // query
            var availableEquipment = _equipments                                                    // query
                .Filter(_equipmentAvailabilitySpecification, skip, take)
                .Select(_mapEquipmentDto.Create)
                .AsQueryable();

            var equipmentViewDto = new EquipmentViewDto                                             // object creation
            {
                EquipmentDtos = availableEquipment,
                ViewDto = new ViewDto                                                               // object creation
                {
                    ViewStateTime = _dateTimeProvider.Now,
                    Skip = skip,
                    Take = take,
                    Total = availableEquipmentCount
                }
            };

            return equipmentViewDto;
        }

        public CartDto SubmitRentRequest(IEnumerable<int> ids, DateTime viewStateTime)
        {
            //create chart, chartEquipment, instance and add it (with start pending state)
            //check if items where available when add took place
            //if items where 
            var time = _dateTimeProvider.Now;
            var cart = new Cart();                                                                  // object creation
            var equipmentItems = ids.Select(o => _equipments.GetById(o));
            var cartEquipment = new CartEquipment                                                   // object creation
            {
                RentState = RentState.StartPending,
                Cart = cart,
                Equipment = null,
                Ip = "",
                AddedDate = time,
                ModifiedDate = time,
                ReturnDate = null,
            };
            _writeDbContext.SaveChanges();
            var chartDto = new CartDto { CartId = cart.Id };                                        // object creation

            return chartDto;
        }

        // doing way too meany thigs
        public InvoiceDto GetInvoice(CartDto cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            var cartequipments = _carts.GetById(cart.CartId).CartEquipments.ToList();               // quering
            var rentals = cartequipments.Select(o =>                                                // mapping
                new RentalDto                                                                       // object creation
                {
                    Name = o.Equipment.EquipmentName,
                    Price = _mapPriceCalculatorLogic                                                // buisiness logic
                        .Create(o.Equipment.EquipmentType)
                        .Calculate(o.RentDurationDays)
                }).ToList();
            var loyaltyPoints = _loyaltyPointsService                                               // buisiness logic
                .GetLoyaltyPoints(cartequipments.Select(o => o.Equipment.EquipmentType)); 
            var total = rentals.Sum(o => o.Price);                                                  // aggregation

            var invoiceDto = new InvoiceDto                                                         // object creation 
            {
                Title = $"Invoice id : {cart.CartId}",
                Rentals = rentals,
                LoyaltyPoints = loyaltyPoints,
                TotalPrice = total
            };

            return invoiceDto;
        }
    }
}
