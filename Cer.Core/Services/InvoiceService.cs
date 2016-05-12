using System;
using Cer.Core.Abstractions;
using Cer.Core.DataTransferObjects;
using Cer.Core.Interfaces;
using Cer.Core.Models;

namespace Cer.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IReadRepository<RentItem, int> _rentItemRepository;

        public InvoiceService(IReadRepository<RentItem, int> rentItemRepository)
        {
            _rentItemRepository = rentItemRepository;
        }

        public InvoiceDto GetInvoice(int rentItemId)
        {
            throw new NotImplementedException();
        }
    }
}