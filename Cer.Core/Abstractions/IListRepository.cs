using System.Collections.Generic;

namespace Cer.Core.Abstractions
{
    public interface IListRepository<out T>
    {
        IEnumerable<T> List();
    }
}