using System;
using System.Linq;
using System.Linq.Expressions;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Service.Implementations;
using Cer.Service.Interfaces;

namespace Cer.Service.Specifications
{
    public class EquipmentAvailabilitySpecification : Specification<Equipment>, IEquipmentAvailabilitySpecification
    {
        public EquipmentAvailabilitySpecification(Expression<Func<Equipment, bool>> expression)
            : base(expression) {}

        public EquipmentAvailabilitySpecification(ISpecification<Equipment> specification)
            : base(specification) {}

        public EquipmentAvailabilitySpecification()
            : base(equipment => equipment.CartEquipments
                .All(o => o.RentState == RentState.Done)) {}
    }
}