using System;
using System.Linq;
using System.Web.Http;
using Cer.Core.Dtos;
using Cer.Core.Interfaces.Services;

namespace Cer.Infrastructure.Proxy.WebApi.Api
{
    public class RentCartController : ApiController
    {
        private readonly IRentalService _rentalService;

        public RentCartController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public CartDto Get(string commaSeparatedIds, DateTime viewStateTime)
        {
            var items = commaSeparatedIds
                .Split(';')
                .Where(string.IsNullOrEmpty)
                .Select(o => o.Split(','))
                .Select(o=>new EquipmentRentDto {
                   EquipmentId = int.Parse(o[0]),
                   DurationInDays = int.Parse(o[1])
                });
            var equipmentRentRequestDto = new EquipmentRentRequestDto
            {
                EquipmentRentDtos = items,
                ViewStateTime = viewStateTime
            }; 
            return _rentalService.SubmitRentRequest(equipmentRentRequestDto);
        }
    }
}
