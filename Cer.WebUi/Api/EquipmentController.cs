﻿using System.Web.Http;
using Cer.Core.Dtos;
using Cer.Core.Interfaces.Services;

namespace Cer.WebUi.Api
{
    public class EquipmentController : ApiController
    {
        private readonly IRentalService _rentalService;

        public EquipmentController()
        {

        }
        public EquipmentController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public EquipmentViewDto Get(int skip=0, int take=20)
        {
            return _rentalService.GetAvailableEquipmentWithPaging(skip, take);
        }
    }
}
