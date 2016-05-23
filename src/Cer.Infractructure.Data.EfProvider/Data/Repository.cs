using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Cer.Core.Abstractions;
using Cer.Core.Interfaces;
using Cer.Infrastructure.Data.EfProvider.Interfaces;

namespace Cer.Infrastructure.Data.EfProvider.Data
{

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        private IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
        public virtual IEnumerable<T> List => Entities;

        public Repository(IDbContext context)
        {
            _context = context;
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TryInvokeDatabaseAction(() =>
            {
                Entities.Add(entity);
                _context.SaveChanges();
            });
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TryInvokeDatabaseAction(() =>
            {
                _context.SaveChanges();
            });
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            TryInvokeDatabaseAction(() =>
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            });
        }

        private void TryInvokeDatabaseAction(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors
                    .Aggregate(string.Empty, (current1, validationErrors) =>
                        validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                            current + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" +
                            Environment.NewLine));

                throw new Exception(msg, dbEx);
            }
        }

        //public IReadOnlyList<T> Filter(ISpecification<T> specification, int skip = 0, int take = 1000)
        //{
        //    return _entities
        //        .AsQueryable()
        //        .Where(specification.Act)
        //        .Skip(skip)
        //        .Take(take)
        //        .ToList();
        //}

        public IReadOnlyList<T> Filter(ISpecification<T> specification, int page = 0)
        {
            return PagedResult(null, specification, page);
        }

        public IReadOnlyList<T> Filter(Expression<Func<T, object>> include, ISpecification<T> specification, int page = 0)
        {
            return Filter(new[] { include }, specification, page);
        }

        public IReadOnlyList<T> Filter(IEnumerable<Expression<Func<T, object>>> includes, ISpecification<T> specification, int page = 0)
        {
            var query = Entities.AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return PagedResult(query, specification, page);
        }
        
        private IReadOnlyList<T> PagedResult(IQueryable<T> query, ISpecification<T> specification, int page, int pageSize = 20)
        {
            return query
                .Where(specification.Act)
                .OrderBy(o => o.Id)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int Total(ISpecification<T> specification)
        {
            return Total((IEnumerable<Expression<Func<T, object>>>)null, specification);
        }

        public int Total(Expression<Func<T, object>> include, ISpecification<T> specification)
        {
            return Total(new[] { include }, specification);
        }

        public int Total(IEnumerable<Expression<Func<T, object>>> includes, ISpecification<T> specification)
        {
            var query = Entities.AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Count(specification.Act);
        }
    }
}
