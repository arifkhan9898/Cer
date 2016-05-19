using System;
using System.Linq;
using System.Linq.Expressions;
using Cer.Core.Interfaces;

namespace Cer.Service.Implementations
{
    public class Specification<T> : ISpecification<T>
    {
        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        {
            return specification.Act;
        }

        public Expression<Func<T, bool>> Act { get; }

        internal Specification(Expression<Func<T, bool>> expression)
        {
            Act = expression;
        }
        public Specification(ISpecification<T> specification) : this(specification.Act)
        {
        }

        public bool IsSatisfiedBy(T entity)
        {
            var query = new[] { entity }.AsQueryable();
            return query.Any(Act);
        }

        internal Expression<Func<T, bool>> Unary(ExpressionType operatorExpression)
        {
            var expressionBody = Expression.MakeUnary(operatorExpression, Act.Body, typeof(T));
            var expressionLambda = Expression.Lambda<Func<T, bool>>(expressionBody, LeftParameters());

            return expressionLambda;
        }

        internal Expression<Func<T, bool>> Binary<TS>(ExpressionType expressionType, TS thatSpecification) where TS : ISpecification<T>
        {
            var leftParameters = LeftParameters();
            var rightParameters = GetRightParameters(thatSpecification, leftParameters);
            var expressionBody = Expression.MakeBinary(expressionType, Act.Body, rightParameters);
            var expressionLambda = Expression.Lambda<Func<T, bool>>(expressionBody, leftParameters);

            return expressionLambda;
        }

        private ParameterExpression LeftParameters()
        {
            return Act.Parameters.First();
        }

        private Expression GetRightParameters(ISpecification<T> thatSpecification, ParameterExpression leftParameters)
        {
            return ReferenceEquals(leftParameters, thatSpecification.Act.Parameters.First())
                ? thatSpecification.Act.Body
                : Expression.Invoke(thatSpecification.Act, leftParameters);
        }
    }
}