using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Place : AggregateRoot
    {
        public string Name { get; set; }

        public void UpdateFrom(Place place)
        {
            Name = place.Name;
        }

        private Place()
        { }

        public static Place Create() 
        {
            return new Place();
        }
    }
}