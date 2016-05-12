using System;
using Cer.Core.Interfaces;

namespace Cer.Core.Abstractions
{
    public abstract class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ip { get; set; }
    }
}