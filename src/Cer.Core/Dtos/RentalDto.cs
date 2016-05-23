using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class RentalDto : BaseDto
    {
        [DataMember(Order = 1)]
        public string Name { get; internal set; }
        [DataMember(Order = 2)]
        public decimal Price { get; internal set; }
    }
}