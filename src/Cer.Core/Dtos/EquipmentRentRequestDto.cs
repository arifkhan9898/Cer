using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Interfaces;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentRentRequestDto : IQuery<CartDto>
    {
        [DataMember(Order = 1)]
        public IEnumerable<EquipmentRentDto> EquipmentRentDtos { get; set; }
        [DataMember(Order = 2)]
        public DateTime ViewStateTime { get; set; }
    }
}