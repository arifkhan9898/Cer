namespace Cer.Core.Abstractions
{
    public interface IReadRepository<out T, in TI> : IListRepository<T>, IIdentifyRepository<T, TI> where T : IIdentifiableEntity<TI>
    {
    }
}