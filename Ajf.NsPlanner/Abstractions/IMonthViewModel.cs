using System;
using System.Collections.ObjectModel;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IMonthViewModel
    {
        void AddDate(IAvailableDateViewModel availableDateViewModel);
        bool ContainsDate(in DateTime date);
        ObservableCollection<IAvailableDateViewModel> Dates { get; set; }
        string Name { get; }
        DateTime FirstInMonth { get; }
    }
}