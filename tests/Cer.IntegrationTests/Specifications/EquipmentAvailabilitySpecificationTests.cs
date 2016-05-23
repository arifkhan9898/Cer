using System.Linq;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.Specifications;
using Cer.Infrastructure.Data.EfProvider.Contextes;
using Cer.Infrastructure.Data.EfProvider.Data;
using NUnit.Framework;

namespace Cer.IntegrationTests.Specifications
{
    [TestFixture]
    public class EquipmentAvailabilitySpecificationTests
    {
        private Repository<Equipment> _equipments;
        private EquipmentAvailabilitySpecification _equipmentAvailabilitySpecification;

        [SetUp]
        public void Init()
        {
            var cerDbContext = new CerDbContext();
            _equipments = new Repository<Equipment>(cerDbContext);
            _equipmentAvailabilitySpecification = new EquipmentAvailabilitySpecification();
        }

        [Test]
        public void FilterReturnsResults()
        {
            var items = _equipments.Filter(o => o.CartEquipments, _equipmentAvailabilitySpecification, 1);

            Assert.True(items.Any());
        }

        [Test]
        public void FilterReturnsResults2()
        {
            var items = _equipments.Filter(o => o.CartEquipments, _equipmentAvailabilitySpecification, 999);

            Assert.False(items.Any());
        }
    }
}
