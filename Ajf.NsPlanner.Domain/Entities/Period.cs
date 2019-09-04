using System;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Period : BaseEntity
    {
        public DateRange DateRange { get; set; }
        public string Target { get; set; }

        private Period(DateRange dateRange, string target)
        {
            DateRange = dateRange;
            Target = target;
        }

        private Period()
        { }

        public static Period Create(DateRange dateRange, string target)
        {
            return new Period(dateRange,target);
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
    }
}