using System;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Service;
using FluentAssertions;
using NUnit.Framework;

namespace Cer.UnitTests.Infrastructure.Business.Service
{
    [TestFixture]
    class MapEquipmentDtoTests
    {
        private IMapper<Equipment, EquipmentDto> _mapper;

        [SetUp]
        public void Init()
        {
            _mapper = new MapEquipmentDto();
        }

        [Test]
        public void Constructor_Throws_If_Equipment_Is_Null()
        {
            // Act, Assert
            Assert.Throws<NullReferenceException>(() => _mapper.Create(null));
        }

        [Test]
        public void Create_Returns_Expected_EquipmentDto()
        {
            var equipment= new Equipment
            {
                EquipmentName = "EquipmentName",
                EquipmentType = EquipmentType.Heavy,
                Id = 2
            };
            var expextedEquipmentDto = new EquipmentDto
            {
                EquipmentName = "EquipmentName",
                EquipmentType = EquipmentType.Heavy,
                Id = 2
            };

            // Act
            var resultEquipmentDto = _mapper.Create(equipment);

            // Assert
            resultEquipmentDto.ShouldBeEquivalentTo(expextedEquipmentDto);
        }
    }
}