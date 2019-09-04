using System.ComponentModel;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IShowAndHideWindows: INotifyPropertyChanged
    {
        bool IsOpen { get; set; }
    }
}