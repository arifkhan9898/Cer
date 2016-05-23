using System;
using System.Linq;
using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Models;
using Cer.Infrastructure.Business.Service.Specifications;

namespace Cer.Infrastructure.Business.Service.QueryHandlers
{
    public class EquipmentViewDtoQueryHandler : IQueryHandler<PagingDto, EquipmentViewDto>
    {
        private readonly IRepository<Equipment> _equipments;
        private readonly IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly EquipmentAvailabilitySpecification _equipmentAvailabilitySpecification;

        public const int PageSize = 25;

        public EquipmentViewDtoQueryHandler(
            IRepository<Equipment> equipments,
            IMapper<Equipment, EquipmentDto> mapEquipmentDto,
            IDateTimeProvider dateTimeProvider,
            EquipmentAvailabilitySpecification equipmentAvailabilitySpecification)
        {
            if (equipments == null)
                throw new ArgumentNullException(nameof(equipments));
            if (mapEquipmentDto == null)
                throw new ArgumentNullException(nameof(mapEquipmentDto));
            if (dateTimeProvider == null)
                throw new ArgumentNullException(nameof(dateTimeProvider));
            if (equipmentAvailabilitySpecification == null)
                throw new ArgumentNullException(nameof(equipmentAvailabilitySpecification));

            _equipments = equipments;
            _mapEquipmentDto = mapEquipmentDto;
            _dateTimeProvider = dateTimeProvider;
            _equipmentAvailabilitySpecification = equipmentAvailabilitySpecification;
        }

        public EquipmentViewDto Handle(PagingDto cartDto)
        {
            var page = Math.Max(cartDto.Page, 0);
            var availableEquipmentCount = _equipments.Total(o => o.CartEquipments, _equipmentAvailabilitySpecification);
            var availableEquipment = _equipments.Filter(o => o.CartEquipments, _equipmentAvailabilitySpecification, page);
            var availableEquipmentDtos = availableEquipment.Select(_mapEquipmentDto.Create).ToList();
            var viewDto = new ViewDto
            {
                ViewStateTime = _dateTimeProvider.Now,
                Page = page,
                PageSize = PageSize,
                Total = availableEquipmentCount
            };
            var equipmentViewDto = new EquipmentViewDto
            {
                EquipmentDtos = availableEquipmentDtos,
                ViewDto = viewDto
            };

            return equipmentViewDto;
        }
    }
}