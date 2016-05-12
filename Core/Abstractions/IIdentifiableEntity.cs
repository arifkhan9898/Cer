namespace Cer.Core.Abstractions
{
    public interface IIdentifiableEntity<T>
    {
        T EntityId { get; set; }
    }
}