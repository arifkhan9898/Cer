using System;
using System.Linq;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.QueryHandlers;
using Cer.Infrastructure.Data.EfProvider.Interfaces;
using Cer.UnitTests.data;
using FluentAssertions;
using Moq;
using NUnit.Framework;
// ReSharper disable ObjectCreationAsStatement

namespace Cer.UnitTests.Cer.Infrastructure.Business.Service.ProviderDtos
{
    [TestFixture]
    public class CartDtoProviderTests
    {
        private CartDtoQueryHandler _cartDtoQueryHandler;
        private IRepository<CartEquipment> _cartEquipments;
        private IRepository<Equipment> _equipments;
        private IDateTimeProvider _dateTimeProvider;
        private IWriteDbContext _writeDbContext;
        private IRepository<Cart> _carts;

        [SetUp]
        public void Init()
        {
            _writeDbContext = Mock.Of<IWriteDbContext>();
            _carts = Mock.Of<IRepository<Cart>>();
            _equipments = Mock.Of<IRepository<Equipment>>();
            _cartEquipments = Mock.Of<IRepository<CartEquipment>>();
            _dateTimeProvider = Mock.Of<IDateTimeProvider>();

            _cartDtoQueryHandler = new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider);
        }

        [Test]
        public void Constructor_Throws_If_WriteDbContext_Is_Null()
        {
            _writeDbContext = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider));
        }

        [Test]
        public void Constructor_Throws_If_Carts_Is_Null()
        {
            _carts = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider));
        }

        [Test]
        public void Constructor_Throws_If_Equipments_Is_Null()
        {
            _equipments = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider));
        }

        [Test]
        public void Constructor_Throws_If_CartEquipment_Is_Null()
        {
            _cartEquipments = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider));
        }

        [Test]
        public void Constructor_Throws_If_DateTimeProvider_Is_Null()
        {
            _dateTimeProvider = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new CartDtoQueryHandler(_writeDbContext, _carts, _equipments, _cartEquipments, _dateTimeProvider));
        }

        [Test, TestCaseSource(
            typeof(TestData.CartDtoProviderTests),
            nameof(TestData.CartDtoProviderTests.HandleValidTestCases))]
        public void SubmitRentRequest_Returns_Expected_EquipmentViewDto(
            EquipmentRentRequestDto input, CartDto expectedResult)
        {
            Mock.Get(_dateTimeProvider)
                .Setup(o => o.Now)
                .Returns(() => TestData.SampleTime);

            // Act
            var result = _cartDtoQueryHandler.SubmitRentRequest(input);

            // Assert
            Mock.Get(_carts)
                .Verify(x => x.Insert(It.IsAny<Cart>()), Times.Once);
            Mock.Get(_cartEquipments)
                .Verify(x => x.Insert(It.IsAny<CartEquipment>()), Times.Exactly(input.EquipmentRentDtos.Count()));
            Mock.Get(_writeDbContext)
                .Verify(x => x.SaveChanges(), Times.Once);

            result.ShouldBeEquivalentTo(expectedResult);
        }
    }
}
