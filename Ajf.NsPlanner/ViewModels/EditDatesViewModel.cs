using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditDatesViewModel : ViewModel, IEditDatesViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly IToggleAvailableDateCommand _toggleAvailableDateCommand;
        private IPeriodViewModel _selectedPeriod;
        private bool _isOpen;

        public EditDatesViewModel(IDispatcher dispatcher, IToggleAvailableDateCommand toggleAvailableDateCommand)
        {
            _dispatcher = dispatcher;
            _toggleAvailableDateCommand = toggleAvailableDateCommand;
            Months = new ObservableCollection<IMonthViewModel>();
            Dates = new ObservableCollection<IAvailableDateViewModel>();
        }

        public string Title => SelectedPeriod==null?"Ingen dato valgt": "Datoer for " + SelectedPeriod.DateRange;

        public ObservableCollection<IAvailableDateViewModel> Dates { get; set; }

        public IPeriodViewModel SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));

                Update();
            }
        }

        public ObservableCollection<IMonthViewModel> Months { get; set; }

        public void Handle(AvailableDateUpdatedEvent domainEvent)
        {
            foreach (var availableDateViewModel in Dates)
                if (availableDateViewModel.Id == domainEvent.AvailableDate.Id)
                    availableDateViewModel.ModelUpdate(domainEvent.AvailableDate);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value; 
                OnPropertyChanged();
            }
        }

        public PositionEtc Get(string name)
        {
            return WindowPositionManager.Get(name);
        }

        public void Set(string name, PositionEtc positionEtc)
        {
            WindowPositionManager.Set(name, positionEtc);
        }

        private void Update()
        {
            Months.Clear();
            Dates.Clear();

            var selectedPeriodId = SelectedPeriod.Id;

            // Ensure all dates are covered
            var existingAvailableDates = _dispatcher.Dispatch(new ListAvailableDatesQuery(selectedPeriodId));

            var availableDatesToCreate = new List<AvailableDate>();

            var numberOfDays = SelectedPeriod.DateRange.NumberOfDays;
            for (var i = 0; i < numberOfDays; i++)
            {
                var date = SelectedPeriod.DateRange.Start.AddDays(i);
                if (existingAvailableDates.All(x => x.Date != date))
                    availableDatesToCreate.Add(AvailableDate.Create(date, selectedPeriodId));
            }

            _dispatcher.Dispatch(new AddAvailableDatesCommand(availableDatesToCreate));

            var models = existingAvailableDates.Concat(availableDatesToCreate).ToArray();

            foreach (var availableDate in models)
            {
                var date = availableDate.Date;

                var availableDateViewModel = new AvailableDateViewModel(availableDate, _toggleAvailableDateCommand);
                Dates.Add(availableDateViewModel);

                var month = Months.SingleOrDefault(x => x.ContainsDate(date));
                if (month == null)
                {
                    month = new MonthViewModel(new DateTime(date.Year, date.Month, 1));
                    Months.Add(month);
                }

                month.AddDate(availableDateViewModel);
            }

            OnPropertyChanged(nameof(Months));
        }
    }
}