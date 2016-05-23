using System;

namespace Cer.Core.Interfaces
{
    public interface IUserContextProvider
    {
        int CurrentUserId { get; }
    }
}
