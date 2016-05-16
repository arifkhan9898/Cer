using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class RentalDto : BaseDto
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public decimal Price { get; private set; }
    }
}