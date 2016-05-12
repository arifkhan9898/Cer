using System.Web.Http;
using Cer.Core.DataTransferObjects;
using Cer.Core.Models;
using Cer.Core.Services;

namespace Cer.WebApi.Api
{
    public class InvoiceController : ApiController
    {
        private readonly IRentalService _rentalService;

        public InvoiceController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        
        public InvoiceDto GetInvoice(RentCart id)
        {
            return _rentalService.GetInvoice(id);
        }
    }
}
