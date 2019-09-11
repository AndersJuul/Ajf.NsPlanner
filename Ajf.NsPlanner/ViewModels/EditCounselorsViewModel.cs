using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
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

        public EditCounselorsViewModel(IDispatcher dispatcher, IToggleAvailableDateCommand toggleAvailableDateCommand)
        {
            CounselorList=new ObservableCollection<CounselorViewModel>();
            _dispatcher = dispatcher;
        }

        public string Title => "Vejledere";


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
                var periodViewModel = new CounselorViewModel(counselor);
                CounselorList.Add(periodViewModel);
            }

            SelectedCounselor = CounselorList.FirstOrDefault();
        }

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
    }
}