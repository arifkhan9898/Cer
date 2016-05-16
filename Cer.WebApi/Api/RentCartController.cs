using System;
using System.Web.Http;
using Cer.Core.Dtos;
using Cer.Core.Interfaces.Services;
using Cer.Core.Models;

namespace Cer.WebApi.Api
{
    public class RentCartController : ApiController
    {
        private readonly IRentalService _rentalService;

        public RentCartController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public CartDto Get(int[] ids, DateTime viewStateTime)
        {
            return _rentalService.SubmitRentRequest(ids, viewStateTime);
        }
    }
}
