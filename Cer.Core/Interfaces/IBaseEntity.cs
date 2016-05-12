using System;

namespace Cer.Core.Interfaces
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string Ip { get; set; }
    }
}