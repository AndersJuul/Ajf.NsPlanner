using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class PlaceUpdatedEvent : BaseDomainEvent
    {
        public Place Place { get; }

        public PlaceUpdatedEvent(Place place)
        {
            Place = place;
        }
    }
}