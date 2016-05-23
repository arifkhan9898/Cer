using System.Web.Http;
using Cer.Core.Dtos;
using Cer.Core.Interfaces.Services;

namespace Cer.Infrastructure.Proxy.WebApi.Api
{
    public class InvoiceController : ApiController
    {
        private readonly IRentalService _rentalService;

        public InvoiceController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        
        public InvoiceDto GetInvoice(CartDto id)
        {
            return _rentalService.GetInvoice(id);
        }
    }
}
