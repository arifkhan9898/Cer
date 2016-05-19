using System;
using System.Linq.Expressions;

namespace Cer.Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Act { get; }
        bool IsSatisfiedBy(T entity);
    }
}