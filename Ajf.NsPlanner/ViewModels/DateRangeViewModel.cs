using System;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class DateRangeViewModel : ViewModel, IDateRangeViewModel
    {
        private DateRange _dateRange;

        private DateRangeViewModel(DateRange dateRange)
        {
            _dateRange = dateRange;
        }

        public DateTime Start
        {
            get => _dateRange.Start;
            set
            {
                _dateRange = DateRange.Create(value, End);
                OnPropertyChanged();
            }
        }

        public DateTime End
        {
            get => _dateRange.End;
            set
            {
                _dateRange = DateRange.Create(Start, value);
                OnPropertyChanged();
            }
        }

        public int NumberOfDays => _dateRange.NumberOfDays;

        public static DateRangeViewModel Create(DateRange dateRange)
        {
            return new DateRangeViewModel(dateRange);
        }

        public override string ToString()
        {
            return Start.ToString("yyyy-MM-dd") + " - " + End.ToString("yyyy-MM-dd");
        }
    }
}