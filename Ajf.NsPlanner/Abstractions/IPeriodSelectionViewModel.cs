using System.Collections.Generic;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IPeriodSelectionViewModel:IViewModel, IHandle<PeriodCreatedEvent>, IHandle<PeriodDeletedEvent>, IHandle<PeriodUpdatedEvent>
    {
        IPeriodViewModel SelectedPeriod { get; set; }
        bool IsPeriodSelected { get; }
        void SetPeriods(IEnumerable<Period> periods);
    }
}