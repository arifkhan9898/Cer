using System;
using System.Collections.Generic;
using System.Net.Http;
using Cer.Core.Dtos;
using Cer.Core.Interfaces.Services;

namespace Cer.WebApiConsumer
{
    public class WebApiConsumerService : IRentalService
    {
        private readonly HttpClient _client;
        public WebApiConsumerService(HttpClient client)
        {
            _client = client;
        }

        //public IEnumerable<Equipment> GetAvailableEquipment()
        //{
        //    var request = $"api/Rental";
        //    var response = _client.GetAsync(request).Result;

        //    return response.IsSuccessStatusCode
        //         ? response.Content.ReadAsAsync<IEnumerable<Equipment>>().Result
        //         : null;
        //}

        //public Cart SubmitRentRequest(IEnumerable<int> ids)
        //{
        //    var request = $"api/Rental";
        //    var response = _client.GetAsync(request).Result;

        //    return response.IsSuccessStatusCode
        //         ? response.Content.ReadAsAsync<Cart>().Result
        //         : null;
        //}

        //public InvoiceDto GetInvoice(Cart cart)
        //{
        //    var request = $"api/Rental/{cart.Id}";
        //    var response = _client.GetAsync(request).Result;
            
        //    return response.IsSuccessStatusCode
        //         ? response.Content.ReadAsAsync<InvoiceDto>().Result
        //         : null;
        //}

        public EquipmentViewDto GetAvailableEquipmentWithPaging(int skip = 0, int take = 20)
        {
            throw new NotImplementedException();
        }

        public CartDto SubmitRentRequest(IEnumerable<int> ids, DateTime viewStateTime)
        {
            throw new NotImplementedException();
        }

        public InvoiceDto GetInvoice(CartDto cart)
        {
            throw new NotImplementedException();
        }
    }
}
