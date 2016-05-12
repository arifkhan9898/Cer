using System.Collections.Generic;
using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        IEnumerable<T> List { get; }
    }
}