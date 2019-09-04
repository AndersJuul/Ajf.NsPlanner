using Ajf.NsPlanner.UI.Models;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IRememberWindowPosition
    {
        PositionEtc Get(string name);
        void Set(string name, PositionEtc positionEtc);
    }
}