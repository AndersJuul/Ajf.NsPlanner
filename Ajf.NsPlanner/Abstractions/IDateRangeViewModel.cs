using System;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IDateRangeViewModel : IViewModel, IComparable, IComparable<DateRangeViewModel>
    {
    }
}