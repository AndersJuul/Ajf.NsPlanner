using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class UpdateCounselorCommand : ICommand
    {
        public Counselor Counselor { get; }

        public UpdateCounselorCommand(Counselor counselor)
        {
            Counselor = counselor;
        }
    }
}