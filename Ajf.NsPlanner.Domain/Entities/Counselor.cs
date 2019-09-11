using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Counselor : AggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static Counselor Create()
        {
            var counselor = new Counselor();
            counselor.Events.Add(new CounselorCreatedEvent(counselor));

            return counselor;
        }

        public void UpdateFrom(Counselor counselor)
        {
            Name = counselor.Name;
            Email = counselor.Email;
            Phone = counselor.Phone;
        }
    }
}