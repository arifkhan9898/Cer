using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class CartDto : BaseDto
    {
        //[DataMember]
        //public IEnumerable<int> CartEquipmentIds { get; private set; }

        [DataMember]
        public long CartId { get; internal set; }
    }
}