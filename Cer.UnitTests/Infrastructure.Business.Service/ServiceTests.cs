﻿using System;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Interfaces;
using Cer.Service;
using Cer.Service.Interfaces;
using Cer.Service.Services;
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
        private IWriteDbContext _writeDbContext;
        private IRepository<Equipment> _equipments;
        private IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
        private IDateTimeProvider _dateTimeProvider;
        private ILoyaltyPointsService _loyaltyPointsService;
        private IMapper<EquipmentType, IRentalCostStrategy> _priceCalculatorLogic;
        [SetUp]
        public void Init()
        {
            var time = new DateTime(2000, 10, 10);
            _carts = Mock.Of<IRepository<Cart>>();
            _writeDbContext = Mock.Of<IWriteDbContext>();
            _equipments = Mock.Of<IRepository<Equipment>>();
            _mapEquipmentDto = Mock.Of<IMapper<Equipment, EquipmentDto>>();
            _dateTimeProvider = Mock.Of<IDateTimeProvider>(o => o.Now == time);
            _loyaltyPointsService = Mock.Of<ILoyaltyPointsService>();
            _priceCalculatorLogic = Mock.Of<IMapper<EquipmentType, IRentalCostStrategy>>();
            _rentalService = new RentalService(_carts, _writeDbContext, _equipments, _mapEquipmentDto, _dateTimeProvider, _loyaltyPointsService, _priceCalculatorLogic);
        }

        [Test]
        public void GetAvailableEquipmentWithPaging_Returns_Expected_EquipmentViewDto()
        {
            var expextedEquipmentViewDto = new EquipmentDto
            {
                EquipmentType = EquipmentType.Heavy,
                EquipmentName = "Attitude",
                Id = 7
            };
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