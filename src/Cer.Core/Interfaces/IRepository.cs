using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>, IFilterRepository<T>, IIncludeFilterRepository<T> where T : BaseEntity
    {
    }
}