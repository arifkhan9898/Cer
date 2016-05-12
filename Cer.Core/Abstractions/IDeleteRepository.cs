namespace Cer.Core.Abstractions
{
    public interface IDeleteRepository<in T>
    {
        void Delete(T item);
    }
}