using System.Collections.ObjectModel;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditAssignmentViewModel : IViewModel, IShowAndHideWindows, IRememberWindowPosition
    {
        CounselorViewModel SelectedCounselor { get; set; }
        ObservableCollection<CounselorViewModel> Counselors { get; }
    }
}