using Ajf.NsPlanner.UI.Views;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class RequestedDialog
    {
        public RequestedDialog(string name, object dataContext, WindowState2 windowState2, bool centerOwner)
        {
            Name = name;
            DataContext = dataContext;
            WindowState2 = windowState2;
            CenterOwner = centerOwner;
        }

        public string Name { get; }
        public object DataContext { get; }
        public WindowState2 WindowState2 { get; set; }
        public bool CenterOwner { get; set; }
    }
}