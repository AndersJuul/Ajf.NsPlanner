using System.ComponentModel;
using System.Windows;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    ///     Interaction logic for StatsEmailAddressesWindow.xaml
    /// </summary>
    public partial class StatsEmailAddressesWindow
    {
        public StatsEmailAddressesWindow()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(
                new DependencyObject()))
                return;

            WindowManager.Register(this);
        }
    }
}