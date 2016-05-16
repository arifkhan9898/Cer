using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Cer.Core.Abstractions;
using Cer.Core.Interfaces;
using Cer.Infrastructure.Interfaces;

namespace Cer.Infrastructure.Data
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
    }
}
