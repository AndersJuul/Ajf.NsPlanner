using System.Collections.ObjectModel;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditAssignmentViewModel : IViewModel, IShowAndHideWindows, IRememberWindowPosition
    {
        CounselorViewModel SelectedCounselor { get; set; }
        ObservableCollection<CounselorViewModel> Counselors { get; }
        PlaceViewModel SelectedPlace { get; set; }
        ObservableCollection<PlaceViewModel> Places { get; }
        void SetCounselors(Counselor[] counselors);
        void SetPlaces(Place[] places);
    }
}