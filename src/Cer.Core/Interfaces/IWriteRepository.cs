using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IWriteRepository<in T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}