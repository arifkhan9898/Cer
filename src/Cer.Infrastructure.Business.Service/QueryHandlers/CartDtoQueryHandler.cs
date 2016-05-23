using System;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Data.EfProvider.Interfaces;

namespace Cer.Infrastructure.Business.Service.QueryHandlers
{
    public class CartDtoQueryHandler : IQueryHandler<EquipmentRentRequestDto, CartDto>
    {
        private readonly IWriteDbContext _writeDbContext;
        private readonly IRepository<Cart> _carts;
        private readonly IRepository<Equipment> _equipments;
        private readonly IRepository<CartEquipment> _cartEquipments;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CartDtoQueryHandler(
            IWriteDbContext writeDbContext,
            IRepository<Cart> carts,
            IRepository<Equipment> equipments,
            IRepository<CartEquipment> cartEquipments,
            IDateTimeProvider dateTimeProvider)
        {
            if (writeDbContext == null)
                throw new ArgumentNullException(nameof(writeDbContext));
            if (carts == null)
                throw new ArgumentNullException(nameof(carts));
            if (equipments == null)
                throw new ArgumentNullException(nameof(equipments));
            if (cartEquipments == null)
                throw new ArgumentNullException(nameof(cartEquipments));
            if (dateTimeProvider == null)
                throw new ArgumentNullException(nameof(dateTimeProvider));

            _writeDbContext = writeDbContext;
            _carts = carts;
            _equipments = equipments;
            _cartEquipments = cartEquipments;
            _dateTimeProvider = dateTimeProvider;
        }

        public CartDto Handle(EquipmentRentRequestDto cartDto)
        {
            return SubmitRentRequest(cartDto);
        }

        public CartDto SubmitRentRequest(EquipmentRentRequestDto equipmentRentRequestDto)
        {
            if (equipmentRentRequestDto == null)
                throw new ArgumentNullException(nameof(equipmentRentRequestDto));
            if (equipmentRentRequestDto.EquipmentRentDtos == null) // todo exception
                throw new Exception(nameof(equipmentRentRequestDto));

            // Todo add messageing Bus.RaiseEvent(new CartStatusPending(cart));

            var cart = new Cart
            {
                AddedDate = _dateTimeProvider.Now,
                ModifiedDate = _dateTimeProvider.Now
            };
            _carts.Insert(cart);

            foreach (var equipmentRentDto in equipmentRentRequestDto.EquipmentRentDtos)
            {
                var equipment = _equipments.GetById(equipmentRentDto.EquipmentId);
                var rentDurationInDays = equipmentRentDto.DurationInDays;
                var cartEquipment = new CartEquipment
                {
                    Cart = cart,
                    Equipment = equipment,
                    RentDurationDays = rentDurationInDays,
                    RentState = RentState.StartPending,
                    AddedDate = _dateTimeProvider.Now,
                    ModifiedDate = _dateTimeProvider.Now,
                    ReturnDate = null
                };
                _cartEquipments.Insert(cartEquipment);
            }
            _writeDbContext.SaveChanges();

            return new CartDto { CartId = cart.Id }; 
        }
    }
}