using System;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IPeriodViewModel : IViewModel
    {
        Guid Id { get; }
        string Target { get; set; }
        DateRangeViewModel DateRange { get; }
        Period Model { get; }
        void NotifyIsCurrentSelection();
        void Save();
        IPeriodViewModel Clone();
    }
}