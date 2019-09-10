using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditCounselorsViewModel : IViewModel, IShowAndHideWindows, IRememberWindowPosition
    {
        void SetCounselors(Counselor[] counselors);
    }
}