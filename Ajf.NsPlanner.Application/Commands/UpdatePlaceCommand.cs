using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.Application.Commands
{
    public class UpdatePlaceCommand : ICommand
    {
        public UpdatePlaceCommand(Place place)
        {
            Place = place;
        }

        public Place Place { get;  }
    }
}