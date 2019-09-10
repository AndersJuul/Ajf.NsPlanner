using System;

namespace Ajf.NsPlanner.Domain.Entities
{
    public class DateRange:IComparable<DateRange>,IComparable
    {
        private DateRange(DateTime start, DateTime end):this()
        {
            Start = start;
            End = end;
        }

        private DateRange()
        {

        }

        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }
        public int NumberOfDays => Convert.ToInt32( End.Subtract(Start).TotalDays)+1;

        public static DateRange Create(DateTime start, DateTime end)
        {
            return new DateRange(start, end);
        }

        public int CompareTo(DateRange other)
        {
            var compareTo = Start.CompareTo(other.Start);
            return compareTo != 0 ? compareTo : End.CompareTo(other.End);
        }

        public int CompareTo(object obj)
        {
            if (obj is DateRange other)
            {
                return CompareTo(other);
            }

            return -1;
        }
    }
}