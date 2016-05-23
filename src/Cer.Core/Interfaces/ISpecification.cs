using System;
using System.Linq.Expressions;

namespace Cer.Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Act { get; }
        bool IsSatisfiedBy(T entity);
    }
    public interface ISpecification<T, TA>
    {
        Expression<Func<T, TA, bool>> Act { get; }
    }
}