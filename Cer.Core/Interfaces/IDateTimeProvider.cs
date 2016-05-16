using System;

namespace Cer.Core.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
