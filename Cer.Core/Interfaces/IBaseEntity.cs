using System;

namespace Cer.Core.Interfaces
{
    public interface IBaseEntity : IIdentifiable
    {
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string Ip { get; set; }
    }
}