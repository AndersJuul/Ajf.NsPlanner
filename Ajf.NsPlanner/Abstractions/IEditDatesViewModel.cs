using System.Collections.ObjectModel;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Events;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditDatesViewModel : IViewModel, IHandle<AvailableDateUpdatedEvent>,IShowAndHideWindows, IRememberWindowPosition
    {
        IPeriodViewModel SelectedPeriod { get; set; }
        ObservableCollection<IMonthViewModel> Months { get; set; }
    }
}