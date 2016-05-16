using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class CartDto : BaseDto
    {
        [DataMember]
        public IEnumerable<int> EquipmentIds { get; private set; }
        [DataMember]
        public long Id { get; private set; }
    }
}