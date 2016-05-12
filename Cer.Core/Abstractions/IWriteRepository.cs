using Cer.Core.Models;

namespace Cer.Core.Abstractions
{
    public interface IWriteRepository<in T> : IDeleteRepository<T>, IUpdateRepository<T>, ICreateRepository<T>
    {
    }
}