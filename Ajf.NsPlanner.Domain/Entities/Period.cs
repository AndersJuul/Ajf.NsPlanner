using System;
using System.Linq;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Period : BaseEntity
    {
        private Period(DateRange dateRange, string target)
        {
            DateRange = dateRange;
            Target = target;
        }

        private Period()
        {
        }

        public DateRange DateRange { get; set; }
        public string Target { get; set; }

        public static Period Create(string target)
        {
            var yearAsString = target.Split(" ").Last();
            var year = Convert.ToInt32(yearAsString);
            var isSpring = target.ToLower().Contains("forår");
            var startMonth = isSpring ? 1 : 7;
            var endMonth = isSpring ? 6 : 12;
            var start = new DateTime(year, startMonth, 1);
            var end = new DateTime(year, endMonth, isSpring ? 30 : 31);
            var dateRange = DateRange.Create(start, end);

            var period = new Period(dateRange, target);
            period.Events.Add(new PeriodCreatedEvent(period));

            return period;
        }

        public void UpdateFrom(Period source)
        {
            DateRange = source.DateRange;
            Target = source.Target;
        }

        public Period Clone()
        {
            var period = new Period(DateRange, Target)
            {
                Id = Id
            };
            return period;
        }

        public AvailableDate CreateAvailableDate(in DateTime date)
        {
            return AvailableDate.Create(date, this);
        }
    }
}