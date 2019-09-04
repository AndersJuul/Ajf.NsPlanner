using System.Windows.Input;
using Ajf.NsPlanner.Domain.Abstractions;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.Abstractions
{
    public interface IDispatcher
    {
        Result Dispatch(ICommand command);
        T Dispatch<T>(IQuery<T> query);
    }
}