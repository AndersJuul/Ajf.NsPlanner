using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class PeriodViewModel : ViewModel, IPeriodViewModel
    {
        private readonly Period _period;
        private readonly IDispatcher _dispatcher;

        public PeriodViewModel(Period period, IDispatcher dispatcher)
        {
            _period = period;
            _dispatcher = dispatcher;
        }

        public DateRangeViewModel DateRange => DateRangeViewModel.Create(_period.DateRange);

        public DateTime Start
        {
            get => _period.DateRange.Start;
            set
            {
                _period.DateRange = Ajf.NsPlanner.Domain.Entities.DateRange.Create(value, End);

                OnPropertyChanged();
                OnPropertyChanged(nameof(DateRange));
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime End
        {
            get => _period.DateRange.End;
            set
            {
                _period.DateRange = Ajf.NsPlanner.Domain.Entities.DateRange.Create(Start, value);

                OnPropertyChanged();
                OnPropertyChanged(nameof(DateRange));
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Title => DateTime.Now.ToLongTimeString();
        public Guid Id => _period.Id;

        public void NotifyIsCurrentSelection()
        {
            OnPropertyChanged(nameof(Title));
        }

        public void Save()
        {
            _dispatcher.Dispatch(new UpdatePeriodCommand(_period));
        }

        public IPeriodViewModel Clone()
        {
            var periodClone=_period.Clone();
            return new PeriodViewModel(periodClone, _dispatcher);
        }

        public string Target
        {
            get => _period.Target;
            set
            {
                _period.Target = value;

                OnPropertyChanged();
            }
        }

        public void ModelUpdate(Period period)
        {
            if (_period.Id != period.Id)
                throw new ArgumentException("Can't update by strange period");

            _period.UpdateFrom(period);

            OnPropertyChanged(nameof(Start));
            OnPropertyChanged(nameof(End));
            OnPropertyChanged(nameof(DateRange));
            OnPropertyChanged(nameof(Target));
            OnPropertyChanged(nameof(Title));
        }
    }
}