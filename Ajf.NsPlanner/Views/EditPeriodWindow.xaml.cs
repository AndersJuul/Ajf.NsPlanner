using System.Windows;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    /// Interaction logic for EditPeriodWindow.xaml
    /// </summary>
    public partial class EditPeriodWindow : Window
    {
        public EditPeriodWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_OnClickOk(object sender, RoutedEventArgs e)
        {
            var periodViewModel = DataContext as IPeriodViewModel;
            periodViewModel.Save();

            Close();
        }
    }
}
