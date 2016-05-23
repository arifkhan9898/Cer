using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;
using Cer.Core.Interfaces;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class InvoiceDto : BaseDto, IQuery<CartDto>
    {
        [DataMember(Order = 1)]
        public string Title { get; internal set; }
        [DataMember(Order = 2)]
        public IEnumerable<RentalDto> Rentals { get; internal set; }
        [DataMember(Order = 3)]
        public decimal TotalPrice { get; internal set; }
        [DataMember(Order = 4)]
        public decimal LoyaltyPoints { get; internal set; }
    }
}