using System;
using Cer.Core.Interfaces;

namespace Cer.Infrastructure.Business.Service.Providers
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}