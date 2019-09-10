using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditCounselorsViewModel : ViewModel, IEditCounselorsViewModel
    {
        private readonly IDispatcher _dispatcher;
        private bool _isOpen;

        public EditCounselorsViewModel(IDispatcher dispatcher, IToggleAvailableDateCommand toggleAvailableDateCommand)
        {
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
    }
}