using System;
using System.Collections.Generic;
using System.Data;
using Ajf.NsPlanner.Domain.SharedKernel;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class Period : BaseEntity
    {
        public DateRange DateRange { get; set; }
        public string Target { get; set; }
        public ICollection<EventRequest> EventRequests { get; set; }
        private Period(DateRange dateRange, string target)
        {
            DateRange = dateRange;
            Target = target;
        }

        private Period()
        {
            EventRequests=new List<EventRequest>();
        }

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

        public AvailableDate CreateAvailableDate(in DateTime date)
        {
            return  AvailableDate.Create(date, this);
        }
    }
}