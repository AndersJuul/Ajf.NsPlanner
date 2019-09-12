using System.Collections.ObjectModel;
using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class EditPlacesViewModel : ViewModel, IEditPlacesViewModel
    {
        public INewPlaceCommand NewPlaceCommand { get; }
        private readonly IDispatcher _dispatcher;
        private bool _isOpen;
        private PlaceViewModel _selectedPlace;

        public EditPlacesViewModel(IDispatcher dispatcher, INewPlaceCommand newPlaceCommand)
        {
            NewPlaceCommand = newPlaceCommand;
            PlaceList=new ObservableCollection<PlaceViewModel>();
            _dispatcher = dispatcher;
        }

        public string Title => "Steder";


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

        public void SetPlaces(Place[] places)
        {
            PlaceList.Clear();
            foreach (var place in places)
            {
                var periodViewModel = new PlaceViewModel(place,_dispatcher);
                PlaceList.Add(periodViewModel);
            }

            SelectedPlace = PlaceList.FirstOrDefault();
        }

        public PlaceViewModel SelectedPlace
        {
            get => _selectedPlace;
            set
            {
                _selectedPlace = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PlaceViewModel> PlaceList { get; set; }
    }
}