using System;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Service;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Cer.UnitTests.Infrastructure.Business.Service
{
    [TestFixture]
    public class RentalServiceTests
    {
        private RentalService _rentalService;
        private IRepository<Cart> _carts;
        private IRepository<CartEquipment> _cartEquipments;
        private IRepository<Equipment> _equipments;
        private IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
        private IDateTimeProvider _dateTimeProvider;

        [SetUp]
        public void Init()
        {
            _carts = Mock.Of<IRepository<Cart>>();
            _cartEquipments = Mock.Of<IRepository<CartEquipment>>();
            _equipments = Mock.Of<IRepository<Equipment>>();
            _mapEquipmentDto = Mock.Of<IMapper<Equipment, EquipmentDto>>();
            _dateTimeProvider = Mock.Of<IDateTimeProvider>();
            _rentalService = new RentalService(_carts, _cartEquipments, _equipments, _mapEquipmentDto, _dateTimeProvider);
        }

        [Test]
        public void GetAvailableEquipmentWithPaging_Returns_Expected_EquipmentViewDto()
        {
            var time = new DateTime(2000, 10, 10);
            var expextedEquipmentViewDto = new EquipmentDto
            {
                EquipmentType = EquipmentType.Heavy,
                EquipmentName = "Attitude",
                Id = 7
            };
            Mock.Get(_dateTimeProvider)
               .Setup(o => o.Now)
               .Returns(time);
            Mock.Get(_equipments)
               .Setup(o => o.List)
               .Returns(new[] { new Equipment() });

            // Act
            var resultEquipmentViewDto = _rentalService.GetAvailableEquipmentWithPaging(0, 20);

            // Assert
            resultEquipmentViewDto.ShouldBeEquivalentTo(expextedEquipmentViewDto);
            Mock.Get(_dateTimeProvider).Verify(o => o.Now, Times.Once);
            Mock.Get(_equipments).Verify(o => o.List, Times.Once);


            // Todo: finish writing tests
        }
    }
}