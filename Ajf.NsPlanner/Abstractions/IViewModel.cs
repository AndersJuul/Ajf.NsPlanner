using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IViewModel: INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}