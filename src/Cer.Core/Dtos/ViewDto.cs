using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Cer.Core.Abstractions;

namespace Cer.Core.Dtos
{
    [DataContract]
    public class ViewDto : BaseDto
    {
        [DataMember(Order = 1)]
        public DateTime ViewStateTime { get; internal set; }
        [DataMember(Order = 2)]
        public int Page { get; internal set; }
        [DataMember(Order = 3)]
        [Range(10, 1000)]
        public int PageSize { get; internal set; }
        [DataMember(Order = 4)]
        public int Total { get; internal set; }
    }
}