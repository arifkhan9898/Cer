using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class RentalDto : BaseDto
    {
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public decimal Price { get; internal set; }
    }
}