using System;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class AvailableDate : AggregateRoot
    {
        public AvailableDate(DateTime date, Guid periodId)
        {
            Date = date;
            PeriodId = periodId;
        }

        public DateTime Date { get; protected set; }
        public Guid PeriodId { get; protected set; }

        public DateAvailability DateAvailability { get; protected set; }

        public static AvailableDate Create(in DateTime date, Guid periodId)
        {
            return new AvailableDate(date, periodId);
        }

        public void Toggle()
        {
            DateAvailability = DateAvailability == DateAvailability.Available
                ? DateAvailability.NotAvailable
                : DateAvailability.Available;

            Events.Add(new AvailableDateUpdatedEvent(this));
        }

        public void UpdateFrom(AvailableDate availableDate)
        {
            DateAvailability= availableDate.DateAvailability;
        }
    }
}