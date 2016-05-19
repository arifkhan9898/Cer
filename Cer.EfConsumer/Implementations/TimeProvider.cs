using System;
using Cer.Core.Interfaces;

namespace Cer.Service.Implementations
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
