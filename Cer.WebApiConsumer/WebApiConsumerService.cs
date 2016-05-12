using System.Collections.Generic;
using System.Net.Http;
using Cer.Core.DataTransferObjects;
using Cer.Core.Models;
using Cer.Core.Services;

namespace Cer.WebApiConsumer
{
    public class WebApiConsumerService : IRentalService
    {
        private readonly HttpClient _client;
        public WebApiConsumerService(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<EquipmentItem> GetAvailableEquipmentItems()
        {
            var request = $"api/Rental";
            var response = _client.GetAsync(request).Result;

            return response.IsSuccessStatusCode
                 ? response.Content.ReadAsAsync<IEnumerable<EquipmentItem>>().Result
                 : null;
        }

        public RentCart SubmitOrder(int[] ids)
        {
            var request = $"api/Rental";
            var response = _client.GetAsync(request).Result;

            return response.IsSuccessStatusCode
                 ? response.Content.ReadAsAsync<RentCart>().Result
                 : null;
        }

        public InvoiceDto GetInvoice(RentCart rentCart)
        {
            var request = $"api/Rental/{rentCart.Id}";
            var response = _client.GetAsync(request).Result;
            
            return response.IsSuccessStatusCode
                 ? response.Content.ReadAsAsync<InvoiceDto>().Result
                 : null;
        }
    }
}
