using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class InvoiceDto : BaseDto
    {
        [DataMember]
        public string Title { get; private set; }
        [DataMember]
        public IEnumerable<RentalDto> Rentals { get; private set; }
        [DataMember]
        public decimal TotalPrice { get; private set; }
        [DataMember]
        public decimal LoyaltyPoints { get; private set; }
    }
}