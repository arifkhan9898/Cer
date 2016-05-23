namespace Cer.Core.Interfaces
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery cartDto);
    }
}