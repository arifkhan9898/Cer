namespace Cer.Core.Abstractions
{
    public interface IIdentifyRepository<out T, in TI> where T : IIdentifiableEntity<TI>
    {
        T GetById(TI id);
    }
}