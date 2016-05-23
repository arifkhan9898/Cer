namespace Cer.Core.Interfaces
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}