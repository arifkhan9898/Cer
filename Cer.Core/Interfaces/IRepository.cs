using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>, IFilterRepository<T> where T : BaseEntity
    {
    }
}