using System.Runtime.Serialization;
using Cer.Core.Abstractions;
using Cer.Core.Enum;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentDto : BaseDto
    {
        [DataMember]
        public long Id { get; internal set; }

        [DataMember(Name = "Name")]
        public string EquipmentName { get; internal set; }

        [DataMember(Name = "Type")]
        public EquipmentType EquipmentType { get; internal set; }
    }
}