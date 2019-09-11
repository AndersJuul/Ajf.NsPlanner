using System.ComponentModel;
using System.Windows;
using Ajf.NsPlanner.UI.Services;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    ///     Interaction logic for EditCounselorsWindow.xaml
    /// </summary>
    public partial class EditCounselorsWindow
    {
        public EditCounselorsWindow()
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

        private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == nameof(CounselorViewModel.Id))
                e.Column.Visibility = Visibility.Hidden;
            if (e.PropertyName == nameof(CounselorViewModel.Model))
                e.Column.Visibility = Visibility.Hidden;
        }
    }
}