using System.Collections.Generic;

namespace Cer.Core.Interfaces
{
    public interface IFilterRepository<T>
    {
        IReadOnlyList<T> Filter(ISpecification<T> specification, int page = 0);
        int Total(ISpecification<T> specification);
    }
}