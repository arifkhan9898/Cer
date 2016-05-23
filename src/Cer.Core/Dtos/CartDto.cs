using System.Runtime.Serialization;
using Cer.Core.Abstractions;
using Cer.Core.Interfaces;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class CartDto : BaseDto, IQuery<InvoiceDto>
    {
        [DataMember(Order = 1)]
        public long CartId { get; internal set; }
    }
}