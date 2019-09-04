using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class UpdatePeriodCommand : ICommand
    {
        public Period Period { get; }

        public UpdatePeriodCommand(Period period)
        {
            Period = period;
        }
    }
}