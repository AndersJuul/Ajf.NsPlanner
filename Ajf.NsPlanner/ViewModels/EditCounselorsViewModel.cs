using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditCounselorsViewModel : ViewModel, IEditCounselorsViewModel
    {
        private readonly IDispatcher _dispatcher;
        private bool _isOpen;
        private CounselorViewModel _selectedCounselor;

        public EditCounselorsViewModel(IDispatcher dispatcher, INewCounselorCommand newCounselorCommand)
        {
            NewCounselorCommand = newCounselorCommand;
            CounselorList = new ObservableCollection<CounselorViewModel>();
            _dispatcher = dispatcher;
        }

        public INewCounselorCommand NewCounselorCommand { get; }

        public string Title => "Vejledere";

        public CounselorViewModel SelectedCounselor
        {
            get => _selectedCounselor;
            set
            {
                _selectedCounselor = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CounselorViewModel> CounselorList { get; set; }


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

        public void SetCounselors(Counselor[] counselors)
        {
            CounselorList.Clear();
            foreach (var counselor in counselors)
            {
                var periodViewModel = new CounselorViewModel(counselor, _dispatcher);
                CounselorList.Add(periodViewModel);
            }

            SelectedCounselor = CounselorList.FirstOrDefault();
        }

        public void Handle(CounselorCreatedEvent domainEvent)
        {
            CounselorList.Add(new CounselorViewModel(domainEvent.Counselor, _dispatcher));
        }
    }
}