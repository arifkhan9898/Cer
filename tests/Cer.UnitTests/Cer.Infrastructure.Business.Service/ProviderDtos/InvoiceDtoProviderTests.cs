using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.Interfaces;
using Cer.Infrastructure.Business.Service.QueryHandlers;
using Cer.UnitTests.data;
using FluentAssertions;
using Moq;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace Cer.UnitTests.Cer.Infrastructure.Business.Service.ProviderDtos
{
    [TestFixture]
    public class InvoiceDtoProviderTests
    {
        private InvoiceDtoQueryHandler _invoiceDtoQueryHandler;
        private IRepository<CartEquipment> _cartEquipment;
        private ILoyaltyPointsProvider _loyaltyPointsProvider;
        private IMapper<EquipmentType, IRentalCostStrategy> _mapPriceCalculatorLogic;
        private IMutablePriceConfiguration _mutablePriceConfiguration;

        [SetUp]
        public void Init()
        {
            _cartEquipment = Mock.Of<IRepository<CartEquipment>>();
            _loyaltyPointsProvider = Mock.Of<ILoyaltyPointsProvider>();
            _mapPriceCalculatorLogic = Mock.Of<IMapper<EquipmentType, IRentalCostStrategy>>();
            _mutablePriceConfiguration = Mock.Of<IMutablePriceConfiguration>();

            _invoiceDtoQueryHandler = new InvoiceDtoQueryHandler(_cartEquipment, _loyaltyPointsProvider,
                _mapPriceCalculatorLogic, _mutablePriceConfiguration);
        }

        [Test]
        public void Constructor_Throws_If_WriteDbContext_Is_Null()
        {
            _cartEquipment = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new InvoiceDtoQueryHandler(_cartEquipment, _loyaltyPointsProvider, _mapPriceCalculatorLogic,
                    _mutablePriceConfiguration));
        }

        [Test]
        public void Constructor_Throws_If_Equipments_Is_Null()
        {
            _loyaltyPointsProvider = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new InvoiceDtoQueryHandler(_cartEquipment, _loyaltyPointsProvider, _mapPriceCalculatorLogic,
                    _mutablePriceConfiguration));
        }

        [Test]
        public void Constructor_Throws_If_CartEquipment_Is_Null()
        {
            _mapPriceCalculatorLogic = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new InvoiceDtoQueryHandler(_cartEquipment, _loyaltyPointsProvider, _mapPriceCalculatorLogic,
                    _mutablePriceConfiguration));
        }

        [Test]
        public void Constructor_Throws_If_DateTimeProvider_Is_Null()
        {
            _mutablePriceConfiguration = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new InvoiceDtoQueryHandler(_cartEquipment, _loyaltyPointsProvider, _mapPriceCalculatorLogic,
                    _mutablePriceConfiguration));
        }

        [Test, TestCaseSource(
            typeof(TestData.InvoiceDtoProviderTests),
            nameof(TestData.InvoiceDtoProviderTests.HandleValidTestCases))]
        public void Handle_Returns_Expected_EquipmentViewDto(
            CartDto cartDto, IReadOnlyList<CartEquipment> cartEquipments, InvoiceDto expectedResult, int loyaltyPoints)
        {
            var page = 0;
            var dict = new Dictionary<EquipmentType, IRentalCostStrategy>
            {
                [EquipmentType.Heavy] = Mock.Of<IRentalCostStrategy>(k =>
                    k.Calculate(It.IsAny<int>(), It.IsAny<IMutablePriceConfiguration>()) == 1),
                [EquipmentType.Regular] = Mock.Of<IRentalCostStrategy>(k =>
                    k.Calculate(It.IsAny<int>(), It.IsAny<IMutablePriceConfiguration>()) == 2),
                [EquipmentType.Specialized] = Mock.Of<IRentalCostStrategy>(k =>
                    k.Calculate(It.IsAny<int>(), It.IsAny<IMutablePriceConfiguration>()) == 3)
            };
            Mock.Get(_cartEquipment)
                .Setup(o => o.Filter(
                    It.IsAny<Expression<Func<CartEquipment, object>>>(),
                    It.IsAny<ISpecification<CartEquipment>>(),
                    page))
                .Returns(() => cartEquipments);
            Mock.Get(_mutablePriceConfiguration).Setup(o => o.OneTimeRentalFee).Returns(100);
            Mock.Get(_mutablePriceConfiguration).Setup(o => o.PremiumDailyFee).Returns(60);
            Mock.Get(_mutablePriceConfiguration).Setup(o => o.RegularDailyFee).Returns(40);
            Mock.Get(_mapPriceCalculatorLogic)
                .Setup(o => o.Create)
                .Returns(o => dict[o]);
            Mock.Get(_loyaltyPointsProvider)
                .Setup(o => o.GetLoyaltyPoints(It.IsAny<IEnumerable<EquipmentType>>()))
                .Returns(loyaltyPoints);

            // Act
            var result = _invoiceDtoQueryHandler.Handle(cartDto);

            // Assert
            Mock.Get(_cartEquipment)
                .Verify(x => x.Filter(
                    It.IsAny<Expression<Func<CartEquipment, object>>>(),
                    It.IsAny<ISpecification<CartEquipment>>(),
                    page), Times.Once);
            Mock.Get(_mapPriceCalculatorLogic)
                .Verify(x => x.Create, Times.Exactly(cartEquipments.Count));
            Mock.Get(_loyaltyPointsProvider)
                .Verify(x => x.GetLoyaltyPoints(It.IsAny<IEnumerable<EquipmentType>>()), Times.Once);
            result.ShouldBeEquivalentTo(expectedResult);
        }
    }
}