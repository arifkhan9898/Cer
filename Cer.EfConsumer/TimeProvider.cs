using System;
using Cer.Core.Interfaces;

namespace Cer.Service
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
