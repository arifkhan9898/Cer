using System.Collections.Generic;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentViewDto : BaseDto
    {
        [DataMember(Name = "Equipment")]
        public IEnumerable<EquipmentDto> EquipmentDtos { get; internal set; }
        [DataMember(Name = "ViewInfo")]
        public ViewDto ViewDto { get; internal set; }
    }
}