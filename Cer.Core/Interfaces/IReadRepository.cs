using System.Collections.Generic;
using System.Linq;
using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IReadRepository<out T> where T : BaseEntity
    {
        IEnumerable<T> List { get; }
        T GetById(object id);
    }
}