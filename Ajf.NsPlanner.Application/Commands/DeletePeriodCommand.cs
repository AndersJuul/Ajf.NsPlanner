using System;
using Ajf.NsPlanner.Application.Abstractions;

namespace Ajf.NsPlanner.Application.Commands
{
    public class DeletePeriodCommand : ICommand
    {
        public DeletePeriodCommand(Guid periodId)
        {
            if(periodId==Guid.Empty)
                throw new ArgumentException("Id can't be empty!");

            PeriodId = periodId;
        }

        public Guid PeriodId { get;  }
    }
}