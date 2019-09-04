using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditAssignmentViewModel : ViewModel
    {
        private readonly Assignment _assignment;
        private readonly IDispatcher _dispatcher;

        public EditAssignmentViewModel(Assignment assignment, IEnumerable<CounselorViewModel> counselorViewModels, IDispatcher dispatcher)
        {
            _assignment = assignment;
            _dispatcher = dispatcher;
            Counselors = new ObservableCollection<CounselorViewModel>(counselorViewModels);
        }

        public CounselorViewModel SelectedCounselor { get; set; }
        public ObservableCollection<CounselorViewModel> Counselors { get; }

        public void CommitChanges()
        {
            try
            {
                _assignment.Counselor = SelectedCounselor?.Model;
                _dispatcher.Dispatch(new UpdateAssignmentCommand(_assignment));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}