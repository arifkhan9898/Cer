using System.Collections.Generic;

namespace Cer.Core.Interfaces
{
    public interface IFilterRepository<T>
    {
        IReadOnlyList<T> Filter(ISpecification<T> specification, int skip = 0, int take = 1000);
        int Total(ISpecification<T> specification);
    }
}