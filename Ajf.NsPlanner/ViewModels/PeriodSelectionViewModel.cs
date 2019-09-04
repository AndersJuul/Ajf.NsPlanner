using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class PeriodSelectionViewModel : ViewModel, IPeriodSelectionViewModel
    {
        private IPeriodViewModel _selectedPeriod;
        private readonly IDispatcher _dispatcher;

        public PeriodSelectionViewModel(INewPeriodCommand newPeriodCommand, IDeletePeriodCommand deletePeriodCommand, IDispatcher dispatcher)
        {
            Id = Guid.NewGuid();

            NewPeriodCommand = newPeriodCommand;
            DeletePeriodCommand = deletePeriodCommand;
            _dispatcher = dispatcher;
            PeriodList = new ObservableCollection<PeriodViewModel>();
        }

        public INewPeriodCommand NewPeriodCommand { get; }
        public IDeletePeriodCommand DeletePeriodCommand { get; }

        public Guid Id { get; set; }

        public ObservableCollection<PeriodViewModel> PeriodList { get; set; }

        public bool IsPeriodSelected => SelectedPeriod != null;

        public IPeriodViewModel SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                if(_selectedPeriod==value)
                    return;

                _selectedPeriod = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPeriodSelected));

                if (_selectedPeriod != null)
                    _selectedPeriod.NotifyIsCurrentSelection();
            }
        }

        public void SetPeriods(IEnumerable<Period> periods)
        {
            PeriodList.Clear();
            foreach (var period in periods)
            {
                var periodViewModel = new PeriodViewModel(period, _dispatcher);
                PeriodList.Add(periodViewModel);
            }

            SelectedPeriod = PeriodList.FirstOrDefault();
        }

        //public void AddPeriod(Period period)
        //{
        //    var vmPeriod = _mapper.Map<PeriodViewModel>(period);
        //    PeriodList.Add(vmPeriod);
        //    SelectedPeriod = vmPeriod;
        //}

        public void Handle(PeriodCreatedEvent domainEvent)
        {
            var periodViewModel = new PeriodViewModel(domainEvent.Period, _dispatcher);
            PeriodList.Add(periodViewModel);
            SelectedPeriod = periodViewModel;
        }

        public void Handle(PeriodDeletedEvent domainEvent)
        {
            var periodViewModel = PeriodList.SingleOrDefault(x => x.Id == domainEvent.Period.Id);
            if (periodViewModel != null)
                PeriodList.Remove(periodViewModel);
            SelectedPeriod = PeriodList.FirstOrDefault();
        }

        public void Handle(PeriodUpdatedEvent domainEvent)
        {
            var periodViewModel = PeriodList.SingleOrDefault(x => x.Id == domainEvent.Period.Id);
            if (periodViewModel != null)
                periodViewModel.ModelUpdate(domainEvent.Period);
        }
    }
}