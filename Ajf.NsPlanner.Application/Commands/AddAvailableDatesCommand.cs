using System.Collections.Generic;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class AddAvailableDatesCommand : ICommand
    {
        public IEnumerable<AvailableDate> AvailableDatesToCreate { get; }

        public AddAvailableDatesCommand(IEnumerable<AvailableDate> availableDatesToCreate)
        {
            AvailableDatesToCreate = availableDatesToCreate;
        }
    }
}