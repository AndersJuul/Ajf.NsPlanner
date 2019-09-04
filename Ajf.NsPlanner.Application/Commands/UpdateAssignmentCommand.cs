using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class UpdateAssignmentCommand : ICommand
    {
        public Assignment Assignment { get; }

        public UpdateAssignmentCommand(Assignment assignment)
        {
            Assignment = assignment;
        }
    }
}