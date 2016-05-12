using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cer.Core.Models;
using Cer.Core.Services;

namespace Cer.WebApi.Api
{
    public class EquipmentItemController : ApiController
    {
        private readonly IRentalService _rentalService;

        public EquipmentItemController()
        {
            
        }
        public EquipmentItemController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IEnumerable<EquipmentItem> Get()
        {
            var items = _rentalService.GetAvailableEquipmentItems().Select(o=>(EquipmentItem)o).ToList();
            return items;
        }
    }
}
