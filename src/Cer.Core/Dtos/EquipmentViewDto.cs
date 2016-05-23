using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentViewDto : BaseDto
    {
        [DataMember(Order = 1, Name = "Equipment")]
        public IEnumerable<EquipmentDto> EquipmentDtos { get; internal set; }
        [DataMember(Order = 2, Name = "ViewInfo")]
        public ViewDto ViewDto { get; internal set; }
    }
}