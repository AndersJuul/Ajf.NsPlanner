using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditCounselorsViewModel : IViewModel, IShowAndHideWindows, IRememberWindowPosition, IHandle<CounselorCreatedEvent>
    {
        void SetCounselors(Counselor[] counselors);
    }
}