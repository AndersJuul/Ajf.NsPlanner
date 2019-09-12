using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ajf.NsPlanner.UI.Services;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    /// Interaction logic for EditPlacesWindow.xaml
    /// </summary>
    public partial class EditPlacesWindow : Window
    {
        public EditPlacesWindow()
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
            if (e.PropertyName == nameof(PlaceViewModel.Id))
                e.Column.Visibility = Visibility.Hidden;

            if (e.PropertyName == nameof(PlaceViewModel.Model))
                e.Column.Visibility = Visibility.Hidden;
        }

    }
}
