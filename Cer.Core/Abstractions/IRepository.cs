namespace Cer.Core.Abstractions
{
    public interface IRepository<T, in TI> : IReadRepository<T, TI>, IWriteRepository<T> where T : IIdentifiableEntity<TI>
    {
    }
}