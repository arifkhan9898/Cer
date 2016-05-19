using System;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Models;

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
}
