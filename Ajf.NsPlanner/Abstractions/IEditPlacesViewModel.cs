using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IEditPlacesViewModel: IViewModel, IShowAndHideWindows, IRememberWindowPosition
    {
        void SetPlaces(Place[] places);
    }
}