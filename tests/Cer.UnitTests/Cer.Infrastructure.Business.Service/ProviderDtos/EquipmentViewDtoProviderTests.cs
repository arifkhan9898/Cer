using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.QueryHandlers;
using Cer.Infrastructure.Business.Service.Specifications;
using Cer.UnitTests.data;
using FluentAssertions;
using Moq;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace Cer.UnitTests.Cer.Infrastructure.Business.Service.ProviderDtos
{
    [TestFixture]
    public class EquipmentViewDtoProviderTests
    {
        private EquipmentViewDtoQueryHandler _equipmentViewDtoQueryHandler;
        private IRepository<Equipment> _equipments;
        private IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
        private IDateTimeProvider _dateTimeProvider;
        private EquipmentAvailabilitySpecification _equipmentAvailabilitySpecification;

        [SetUp]
        public void Init()
        {
            _equipments = Mock.Of<IRepository<Equipment>>();
            _mapEquipmentDto = Mock.Of<IMapper<Equipment, EquipmentDto>>();
            _dateTimeProvider = Mock.Of<IDateTimeProvider>();
            _equipmentAvailabilitySpecification = Mock.Of<EquipmentAvailabilitySpecification>();

            _equipmentViewDtoQueryHandler = new EquipmentViewDtoQueryHandler(_equipments, _mapEquipmentDto, _dateTimeProvider,
                _equipmentAvailabilitySpecification);
        }

        [Test]
        public void Constructor_Throws_If_Equipments_Is_Null()
        {
            _equipments = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new EquipmentViewDtoQueryHandler(_equipments, _mapEquipmentDto, _dateTimeProvider,
                    _equipmentAvailabilitySpecification));
        }

        [Test]
        public void Constructor_Throws_If_MapEquipmentDto_Is_Null()
        {
            _mapEquipmentDto = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new EquipmentViewDtoQueryHandler(_equipments, _mapEquipmentDto, _dateTimeProvider,
                    _equipmentAvailabilitySpecification));
        }

        [Test]
        public void Constructor_Throws_If_DateTimeProvider_Is_Null()
        {
            _dateTimeProvider = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new EquipmentViewDtoQueryHandler(_equipments, _mapEquipmentDto, _dateTimeProvider,
                    _equipmentAvailabilitySpecification));
        }

        [Test]
        public void Constructor_Throws_If_EquipmentAvailabilitySpecification_Is_Null()
        {
            _equipmentAvailabilitySpecification = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new EquipmentViewDtoQueryHandler(_equipments, _mapEquipmentDto, _dateTimeProvider,
                    _equipmentAvailabilitySpecification));
        }

        [Test, TestCaseSource(
            typeof(TestData.EquipmentViewDtoProviderTests), 
            nameof(TestData.EquipmentViewDtoProviderTests.HandleValidTestCases))]
        public void Handle_Returns_Expected_EquipmentViewDto(
            int total, IReadOnlyList<Equipment> equipments, Func<Equipment, EquipmentDto> mapper, PagingDto page,
            EquipmentViewDto expectedResult)
        {
            Mock.Get(_equipments)
                .Setup(o => o.Total(It.IsAny<ISpecification<Equipment>>()))
                .Returns(() => total);
            Mock.Get(_equipments)
                .Setup(o => o.Filter(
                    It.IsAny<Expression<Func<Equipment, object>>>(),
                    It.IsAny<ISpecification<Equipment>>(),
                    It.IsAny<int>()))
                .Returns(() => equipments);
            Mock.Get(_dateTimeProvider)
                .Setup(o => o.Now)
                .Returns(() => TestData.SampleTime);
            Mock.Get(_mapEquipmentDto)
                .Setup(o => o.Create)
                .Returns(() => mapper);

            // Act
            var result = _equipmentViewDtoQueryHandler.Handle(page);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }
    }
}