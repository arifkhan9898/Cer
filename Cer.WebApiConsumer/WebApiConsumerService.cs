using System.Collections.Generic;
using System.Net.Http;
using Cer.Core.DataTransferObjects;
using Cer.Core.Interfaces;
using Cer.Core.Models;

namespace Cer.WebApiConsumer
{
    public class WebApiConsumerService : IInvoiceService, IRentItemService
    {
        private readonly HttpClient _client;

        public WebApiConsumerService(HttpClient client)
        {
            _client = client;
        }

        public InvoiceDto GetInvoice(int rentItemId)
        {
            var request = $"api/invoice?rentItemId={rentItemId}";
            var response = _client.GetAsync(request).Result;
            
            return response.IsSuccessStatusCode
                 ? response.Content.ReadAsAsync<InvoiceDto>().Result
                 : null;
        }

        public IEnumerable<RentItem> GetAvailableRentItems()
        {
            var request = $"api/rentItem";
            var response = _client.GetAsync(request).Result;

            return response.IsSuccessStatusCode
                 ? response.Content.ReadAsAsync<IEnumerable<RentItem>>().Result
                 : null;
        }
    }
}
