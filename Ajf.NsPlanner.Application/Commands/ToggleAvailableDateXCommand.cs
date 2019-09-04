using System;
using Ajf.NsPlanner.Application.Abstractions;

namespace Ajf.NsPlanner.Application.Commands
{
    public class ToggleAvailableDateXCommand : ICommand
    {
        public Guid AvailableDateId { get; }

        public ToggleAvailableDateXCommand(Guid availableDateId)
        {
            AvailableDateId = availableDateId;
        }
    }
}