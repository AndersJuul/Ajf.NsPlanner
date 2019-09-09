using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class PeriodViewModel : ViewModel, IPeriodViewModel
    {
        private readonly IDispatcher _dispatcher;

        public PeriodViewModel(Period period, IDispatcher dispatcher)
        {
            Model = period;
            _dispatcher = dispatcher;
        }

        public DateRangeViewModel DateRange => DateRangeViewModel.Create(Model.DateRange);
        public Period Model { get; }

        public DateTime Start
        {
            get => Model.DateRange.Start;
            set
            {
                Model.DateRange = Ajf.NsPlanner.Domain.Entities.DateRange.Create(value, End);

                OnPropertyChanged();
                OnPropertyChanged(nameof(DateRange));
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime End
        {
            get => Model.DateRange.End;
            set
            {
                Model.DateRange = Ajf.NsPlanner.Domain.Entities.DateRange.Create(Start, value);

                OnPropertyChanged();
                OnPropertyChanged(nameof(DateRange));
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Title => DateTime.Now.ToLongTimeString();
        public Guid Id => Model.Id;

        public void NotifyIsCurrentSelection()
        {
            OnPropertyChanged(nameof(Title));
        }

        public void Save()
        {
            _dispatcher.Dispatch(new UpdatePeriodCommand(Model));
        }

        public IPeriodViewModel Clone()
        {
            var periodClone=Model.Clone();
            return new PeriodViewModel(periodClone, _dispatcher);
        }

        public string Target
        {
            get => Model.Target;
            set
            {
                Model.Target = value;

                OnPropertyChanged();
            }
        }

        public void ModelUpdate(Period period)
        {
            if (Model.Id != period.Id)
                throw new ArgumentException("Can't update by strange period");

            Model.UpdateFrom(period);

            OnPropertyChanged(nameof(Start));
            OnPropertyChanged(nameof(End));
            OnPropertyChanged(nameof(DateRange));
            OnPropertyChanged(nameof(Target));
            OnPropertyChanged(nameof(Title));
        }
    }
}