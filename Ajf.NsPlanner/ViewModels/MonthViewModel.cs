using System;
using System.Collections.ObjectModel;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class MonthViewModel:ViewModel, IMonthViewModel
    {
        public DateTime FirstInMonth { get; }

        public MonthViewModel(DateTime firstInMonth)
        {
            FirstInMonth = firstInMonth;

            Dates=new   ObservableCollection<IAvailableDateViewModel>();
        }

        public void AddDate(IAvailableDateViewModel availableDateViewModel)
        {
            Dates.Add(availableDateViewModel);
        }

        public ObservableCollection<IAvailableDateViewModel> Dates { get; set; }
        public string Name => FirstInMonth.ToString("MMMM");

        public bool ContainsDate(in DateTime date)
        {
            return date.Year == FirstInMonth.Year && date.Month == FirstInMonth.Month;
        }
    }
}