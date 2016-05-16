using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class ViewDto : BaseDto
    {
        [DataMember]
        public DateTime ViewStateTime { get; internal set; }
        [DataMember]
        public int Skip { get; internal set; }
        [DataMember]
        [Range(10, 1000)]
        public int Take { get; internal set; }
        [DataMember]
        public int Total { get; internal set; }
    }
}