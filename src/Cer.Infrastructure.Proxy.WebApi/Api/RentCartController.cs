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

        public CartDto Get(string commaSeparatedIdAndDurationTuples)
        {
            // Todo: think about if parsing data belongs here or not
            var items = commaSeparatedIdAndDurationTuples
                .Split('-')
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => o.Split(','))
                .Select(o => new EquipmentRentDto
                {
                    EquipmentId = int.Parse(o[0]),
                    DurationInDays = int.Parse(o[1])
                })
                .ToList();
            var equipmentRentRequestDto = new EquipmentRentRequestDto
            {
                EquipmentRentDtos = items,
                //ViewStateTime = viewStateTime - can be faked
            };
            return _rentalService.SubmitRentRequest(equipmentRentRequestDto);
        }
    }
}
