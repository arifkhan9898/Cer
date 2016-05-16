using System;
using System.Collections.Generic;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;

namespace Cer.Service.Maps
{
    public class MapEquipmentViewDto : IMapper<IEnumerable<EquipmentDto>, ViewDto, EquipmentViewDto>
    {
        public Func<IEnumerable<EquipmentDto>, ViewDto, EquipmentViewDto> Create => (equipmentDto, viewDto) =>
        {
            if (equipmentDto == null)
                throw new NullReferenceException(nameof(equipmentDto));
            if (viewDto == null)
                throw new NullReferenceException(nameof(viewDto));

            return new EquipmentViewDto
            {
                EquipmentDtos = equipmentDto,
                ViewDto = viewDto
            };
        };
    }
}