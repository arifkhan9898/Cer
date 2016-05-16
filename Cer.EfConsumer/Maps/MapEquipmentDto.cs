using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Service.Logics;

namespace Cer.Service.Maps
{
    public class MapEquipmentDto : IMapper<Equipment, EquipmentDto>
    {
        public Func<Equipment, EquipmentDto> Create => equipment =>
        {
            if (equipment == null)
                throw new NullReferenceException(nameof(equipment));
            if (equipment.EquipmentName == null)
                throw new ArgumentNullException(nameof(equipment));

            return new EquipmentDto
            {
                Id = equipment.Id,
                EquipmentName = equipment.EquipmentName,
                EquipmentType = equipment.EquipmentType
            };
        };
    }
    public class MapPriceCalculatorLogic : IMapper<EquipmentType, PriceCalculatorLogic>
    {

        public Func<EquipmentType, PriceCalculatorLogic> Create => equipment =>
        {
            var known = new Dictionary<EquipmentType, PriceCalculatorLogic>
            {
                { EquipmentType.Heavy, new HeavyPriceCalculatorLogic()},
                { EquipmentType.Specialized, new SpecializedPriceCalculatorLogic()},
                { EquipmentType.Regular, new RegularPriceCalculatorLogic()}
            };
            if (!known.ContainsKey(equipment))
                throw new ArgumentException();

            return known[equipment];
        };
    }
}
