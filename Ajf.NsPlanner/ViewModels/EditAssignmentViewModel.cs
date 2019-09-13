using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
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

            _assignmentsViewModel.PropertyChanged += SelectedAssignment_PropertyChanged;
        }

        public IAssignmentViewModel SelectedAssignment => _assignmentsViewModel.SelectedAssignment;

        public string TimeStamp => _assignmentsViewModel.SelectedAssignment?.TimeStamp;

        public string Desire => _assignmentsViewModel.SelectedAssignment?.Desire;

        public CounselorViewModel SelectedCounselor { get; set; }
        public ObservableCollection<CounselorViewModel> Counselors { get; }

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

        private void SelectedAssignment_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AssignmentsViewModel.SelectedAssignment))
                OnPropertyChanged(nameof(SelectedAssignment));
        }

        public void CommitChanges()
        {
            try
            {
                _assignmentsViewModel.SelectedAssignment.Assignment.Counselor = SelectedCounselor?.Model;
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