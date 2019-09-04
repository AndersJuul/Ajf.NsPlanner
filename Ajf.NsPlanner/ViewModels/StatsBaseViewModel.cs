using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public abstract class StatsBaseViewModel<T, T2> : ViewModel, ISimpleStatsViewModel
        where T : IQuery<T2> where T2 : SimpleStatTable
    {
        private readonly IDispatcher _dispatcher;
        private bool _isOpen;
        private IPeriodViewModel _selectedPeriod;
        private SimpleStatTable _statTable;

        public StatsBaseViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public abstract string Title { get; }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        }

        public IPeriodViewModel SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
                Recalculate();
            }
        }

        public SimpleStatTable StatTable
        {
            get => _statTable;
            set
            {
                _statTable = value;
                OnPropertyChanged();
            }
        }

        public string Translate(string columnName)
        {
            var dictionary = new Dictionary<string, string>
            {
                {"InstOrSchool", "Inst/Skole"},
                {"AcceptedCount", "Antal efterkommet"},
                {"RejectedCount", "Antal afvist"},
                {"Total", "Ialt"},
                {"Email", "Email"},
                {"Count", "Antal"},
                {"SchoolInstituteName", "Navn"}
            };

            return dictionary[columnName];
        }

        public PositionEtc Get(string name)
        {
            return WindowPositionManager.Get(name);
        }

        public void Set(string name, PositionEtc positionEtc)
        {
            WindowPositionManager.Set(name, positionEtc);
        }

        public void Handle(AssignmentUpdatedEvent domainEvent)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            var currentAssignments = GetCurrentAssignments();
            StatTable = _dispatcher.Dispatch(GetQuery(currentAssignments));
        }

        protected abstract T GetQuery(Assignment[] currentAssignments);

        private Assignment[] GetCurrentAssignments()
        {
            return SelectedPeriod.Target == null
                ? new Assignment[] { }
                : _dispatcher
                    .Dispatch(
                        new FindAssignmentsByTargetQuery(
                            SelectedPeriod.Target,
                            new List<Func<IQueryable<Assignment>, IQueryable<Assignment>>>()
                        )
                    );
        }
    }
}