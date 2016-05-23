using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cer.Core.Interfaces
{
    public interface IIncludeFilterRepository<T>
    {
        IReadOnlyList<T> Filter(Expression<Func<T, object>> include, ISpecification<T> specification, int page = 0);
        IReadOnlyList<T> Filter(IEnumerable<Expression<Func<T, object>>> includes, ISpecification<T> specification, int page = 0);
        int Total(Expression<Func<T, object>> include, ISpecification<T> specification);
        int Total(IEnumerable<Expression<Func<T, object>>> includes, ISpecification<T> specification);
    }
}