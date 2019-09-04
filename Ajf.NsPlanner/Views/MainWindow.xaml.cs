using System;
using System.ComponentModel;
using System.Windows;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
                if (e.NewValue is MainWindowViewModel model)
                    model.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is MainWindowViewModel model)
                if (e.PropertyName == nameof(MainWindowViewModel.RequestedDialog))
                {
                    Window w = null;
                    if (model.RequestedDialog.Name == "C")
                        w = new EditAssignmentCounselorWindow();

                    if (model.RequestedDialog.Name == "P")
                        w = new EditPeriodWindow();

                    if (w == null) return;

                    w.Owner = this;

                    if (model.RequestedDialog.CenterOwner)
                        w.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    w.DataContext = model.RequestedDialog.DataContext;

                    if (model.RequestedDialog.WindowState2 == WindowState2.ShowDialog)
                        w.ShowDialog();
                    if (model.RequestedDialog.WindowState2 == WindowState2.Show)
                        w.Show();
                }
        }

        private void EditPeriodClick(object sender, RoutedEventArgs e)
        {
            var mainWindowViewModel = DataContext as IMainWindowViewModel;
            if (mainWindowViewModel == null)
                throw new ArgumentException("mainWindowViewModel");

            var periodViewModel = mainWindowViewModel?.PeriodSelectionViewModel?.SelectedPeriod;
            if (periodViewModel == null)
                throw new ArgumentException("No period selected.");

            // Open editing on a clone. If changes are persisted, the source period will be updated based on domain event
            new EditPeriodWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = periodViewModel.Clone()
            }.ShowDialog();
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindowViewModel = DataContext as IMainWindowViewModel;
            if (mainWindowViewModel != null)
                mainWindowViewModel.OnLoaded();
        }
    }
}