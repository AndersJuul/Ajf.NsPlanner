using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditAssignmentViewModel : ViewModel, IEditAssignmentViewModel
    {
        private readonly IAssignmentsViewModel _assignmentsViewModel;
        private readonly IDispatcher _dispatcher;
        private bool _isOpen;

        public EditAssignmentViewModel(IEnumerable<CounselorViewModel> counselorViewModels,
            IDispatcher dispatcher, IAssignmentsViewModel assignmentsViewModel)
        {
            _dispatcher = dispatcher;
            _assignmentsViewModel = assignmentsViewModel;

            Counselors = new ObservableCollection<CounselorViewModel>(counselorViewModels);
            Places=new ObservableCollection<PlaceViewModel>();

            _assignmentsViewModel.PropertyChanged += SelectedAssignment_PropertyChanged;
        }
        public string Title => "Detaljer for ønske.";


        public IAssignmentViewModel SelectedAssignment => _assignmentsViewModel.SelectedAssignment;

        public string TimeStamp => _assignmentsViewModel.SelectedAssignment?.TimeStamp;

        public string Desire => _assignmentsViewModel.SelectedAssignment?.Desire;

        public CounselorViewModel SelectedCounselor
        {
            get => Counselors.SingleOrDefault(x=>x.Id== _assignmentsViewModel.SelectedAssignment?.Assignment?.Counselor?.Id);
            set
            {
                _assignmentsViewModel.SelectedAssignment.Assignment.Counselor = value?.Model; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CounselorViewModel> Counselors { get; }
        public void SetCounselors(Counselor[] counselors)
        {
            var selectedBefore = SelectedCounselor?.Id ?? Guid.Empty;
            Counselors.Clear();

            foreach (var counselor in counselors)
            {
                Counselors.Add(new CounselorViewModel(counselor, _dispatcher));
            }
        }
        public PlaceViewModel SelectedPlace { get; set; }
        public ObservableCollection<PlaceViewModel> Places { get; }
        public void SetPlaces(Place[] places)
        {
            var selectedBefore = SelectedPlace?.Id ?? Guid.Empty;
            Places.Clear();

            foreach (var place in places)
            {
                Places.Add(new PlaceViewModel(place, _dispatcher));
            }

            SelectedPlace = Places.SingleOrDefault(x => x.Id == selectedBefore);
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

        public void Reset(string name)
        {
            var positionEtc = WindowPositionManager.Get(name);
            positionEtc.Left = 0;
            positionEtc.Top = 0;
            WindowPositionManager.Set(name, positionEtc);
        }

        private void SelectedAssignment_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AssignmentsViewModel.SelectedAssignment))
            {
                OnPropertyChanged(nameof(SelectedAssignment));
                OnPropertyChanged(nameof(SelectedCounselor));
            }
        }

        public void CommitChanges()
        {
            try
            {
                _assignmentsViewModel.SelectedAssignment.Assignment.Counselor = SelectedCounselor?.Model;
                _assignmentsViewModel.SelectedAssignment.Assignment.Place = SelectedPlace?.Model;
                _dispatcher.Dispatch(new UpdateAssignmentCommand(_assignmentsViewModel.SelectedAssignment.Assignment));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}