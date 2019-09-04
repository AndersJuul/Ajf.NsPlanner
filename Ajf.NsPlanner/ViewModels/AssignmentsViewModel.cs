using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.Domain.Queries;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class AssignmentsViewModel: ViewModel, IAssignmentsViewModel
    {
        private AssignmentViewModel _selectedAssignment;
        private readonly IDispatcher _dispatcher;
        private bool _filterHideUnspecified;
        private bool _filterHideFullySpecified;
        private bool _filterHidePartlySpecified;
        private string _target;
        private string _filterMark;
        public string Title => "Tildelinger";

        public string Target
        {
            get { return _target; }
            set
            {
                _target = value;
                OnPropertyChanged();
                ReloadAssignmentsFromDb();
            }
        }

        public ObservableCollection<AssignmentViewModel> Items { get; }

        public bool ShowIdColumn { get; set; } = false;

        public AssignmentViewModel SelectedAssignment
        {
            get => _selectedAssignment;
            set
            {
                _selectedAssignment = value;
                OnPropertyChanged();
            }
        }

        public bool FilterHideUnspecified
        {
            get => _filterHideUnspecified;
            set
            {
                _filterHideUnspecified = value;
                OnPropertyChanged();
                ReloadAssignmentsFromDb();
            }
        }

        public bool FilterHideFullySpecified
        {
            get => _filterHideFullySpecified;
            set
            {
                _filterHideFullySpecified = value;
                OnPropertyChanged();
                ReloadAssignmentsFromDb();
            }
        }

        public bool FilterHidePartlySpecified
        {
            get => _filterHidePartlySpecified;
            set
            {
                _filterHidePartlySpecified = value;
                OnPropertyChanged();
                ReloadAssignmentsFromDb();
            }
        }
        public string FilterMark
        {
            get => _filterMark;
            set
            {
                _filterMark= value;
                OnPropertyChanged();
                ReloadAssignmentsFromDb();
            }
        }


        public AssignmentsViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            Items = new ObservableCollection<AssignmentViewModel>();

            ReloadAssignmentsFromDb();
        }

        public void ReloadAssignmentsFromDb()
        {
            var assignments = GetCurrentAssignments();
            SetAssignments(assignments);
        }

        private Assignment[] GetCurrentAssignments()
        {
            var funcs =new List<Func<IQueryable<Assignment>, IQueryable<Assignment>>>();

            if (FilterHideUnspecified)
                funcs.Add(x => x.Where(xx => xx.SpecificationStatus != SpecificationStatus.Unspecified));

            if (FilterHideFullySpecified)
                funcs.Add(x => x.Where(xx => xx.SpecificationStatus != SpecificationStatus.FullySpecified));

            if (FilterHidePartlySpecified)
                funcs.Add(x => x.Where(xx => xx.SpecificationStatus != SpecificationStatus.PartlySpecified));

            if(!string.IsNullOrEmpty(FilterMark))
                funcs.Add( x=> x.Where(xx=>FilterMark.Contains( xx.Marker)));
            
            return Target == null
                ? new Assignment[] { }
                : _dispatcher.Dispatch(new FindAssignmentsByTargetQuery(Target,funcs));
        }

        private void SetAssignments(Assignment[] assignments)
        {
            var oldSelectedAssignment = SelectedAssignment;

            Items.Clear();
            foreach (var assignment in assignments)
            {
                Items.Add(new AssignmentViewModel(assignment));
            }

            var newCopyOfOldSelectedItem = Items.SingleOrDefault(x => x.Id == oldSelectedAssignment?.Id);
            SelectedAssignment = newCopyOfOldSelectedItem ?? Items.FirstOrDefault();
        }

        public void Handle(AssignmentUpdatedEvent domainEvent)
        {
            var assignmentViewModel = Items
                .SingleOrDefault(x => x.Id == domainEvent.Assignment.Id);

            assignmentViewModel?.ModelUpdate(domainEvent.Assignment);
        }

        public void Handle(EventRequestUpdatedEvent domainEvent)
        {
            var assignmentViewModel = Items
                .SingleOrDefault(x => x.RefersEventRequest(domainEvent.EventRequest));

            assignmentViewModel?.NotifyAll();
        }
    }
}