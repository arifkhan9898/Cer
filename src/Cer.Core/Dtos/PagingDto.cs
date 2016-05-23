using System.Runtime.Serialization;
using Cer.Core.Interfaces;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class PagingDto : IQuery<EquipmentViewDto>
    {
        [DataMember(Order = 1)]
        public int Page { get; set; }
    }
}