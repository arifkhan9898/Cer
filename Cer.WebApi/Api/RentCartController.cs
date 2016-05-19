using System;
using System.Collections.Generic;
using System.Linq;
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

        public CartDto Get(string commaSeparatedIds, DateTime viewStateTime)
        {
            var items = commaSeparatedIds.Split(',').Where(string.IsNullOrEmpty).Select(int.Parse);
            return _rentalService.SubmitRentRequest(items, viewStateTime);
        }
    }
}
