using Cer.Core.Abstractions;

namespace Cer.Core.Interfaces
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : BaseEntity
    {
    }
}
