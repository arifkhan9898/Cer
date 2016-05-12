using System.Web.Http;
using Cer.Core.Models;
using Cer.Core.Services;

namespace Cer.WebApi.Api
{
    public class RentCartController : ApiController
    {
        private readonly IRentalService _rentalService;

        public RentCartController(IRentalService rentalService )
        {
            _rentalService = rentalService;
        }

        public RentCart Get(int[] ids)
        {
            return _rentalService.SubmitOrder(ids);
        }

    }
}
