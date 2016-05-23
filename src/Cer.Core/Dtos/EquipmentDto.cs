using System.Runtime.Serialization;
using Cer.Core.Abstractions;
using Cer.Core.Enum;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentDto : BaseDto
    {
        [DataMember(Order = 1)]
        public long Id { get; internal set; }

        [DataMember(Order = 2, Name = "Name")]
        public string EquipmentName { get; internal set; }

        [DataMember(Order = 3, Name = "Type")]
        public EquipmentType EquipmentType { get; internal set; }
    }
}