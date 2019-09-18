using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditPlacesViewModel: IViewModel, IShowAndHideWindows, IRememberWindowPosition, IHandle<PlaceCreatedEvent>
    {
        void SetPlaces(Place[] places);
    }
}