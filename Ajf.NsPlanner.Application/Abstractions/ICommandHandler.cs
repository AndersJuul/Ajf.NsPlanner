using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.Abstractions
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }


}