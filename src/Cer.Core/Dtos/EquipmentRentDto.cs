using System.Runtime.Serialization;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class EquipmentRentDto
    {
        [DataMember(Order = 1)]
        public long EquipmentId { get; set; }
        // client server have different time zones, times
        [DataMember(Order = 2)]
        public int DurationInDays { get; set; }
        // should maybe add starting fromdateime field
        // what if that time is in past 
    }
}