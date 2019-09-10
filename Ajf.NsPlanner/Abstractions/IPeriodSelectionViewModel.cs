using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IPeriodSelectionViewModel:IViewModel, IHandle<PeriodCreatedEvent>, IHandle<PeriodDeletedEvent>, IHandle<PeriodUpdatedEvent>
    {
        IPeriodViewModel SelectedPeriod { get; set; }
        bool IsPeriodSelected { get; }
        ObservableCollection<PeriodViewModel> PeriodList { get; set; }
        void SetPeriods(IEnumerable<Period> periods);
    }
}