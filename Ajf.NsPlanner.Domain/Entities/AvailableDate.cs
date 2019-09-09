using System;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class AvailableDate : AggregateRoot
    {
        private AvailableDate()
        {
        }

        internal AvailableDate(DateTime date, Period period)
        {
            Date = date;
            Period = period;
        }

        public DateTime Date { get; protected set; }

        public DateAvailability DateAvailability { get; protected set; }
        public Period Period { get; protected set; }

        public static AvailableDate Create(in DateTime date, Period period)
        {
            return new AvailableDate(date, period);
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
            DateAvailability = availableDate.DateAvailability;
        }
    }
}