using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Events
{
    public class PlaceCreatedEvent : BaseDomainEvent
    {
        public Place Place { get; }

        public PlaceCreatedEvent(Place place)
        {
            Place = place;
        }
    }
}