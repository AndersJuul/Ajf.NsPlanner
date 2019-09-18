using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    /// Interaction logic for EditAssignmentPlaceWindow.xaml
    /// </summary>
    public partial class EditAssignmentPlaceWindow : Window
    {
        public EditAssignmentPlaceWindow()
        {
            InitializeComponent();

            var firstSettings = new RoutedCommand();
            firstSettings.InputGestures.Add(new KeyGesture(Key.F6, ModifierKeys.None));
            firstSettings.InputGestures.Add(new KeyGesture(Key.Enter, ModifierKeys.None));
            CommandBindings.Add(new CommandBinding(firstSettings, CommitChangesAndClose));

            ListView.Focus();
        }

        private void CommitChangesAndClose(object sender, ExecutedRoutedEventArgs e)
        {
            if (DataContext is EditAssignmentViewModel model)
            {
                model.CommitChanges();
            }

            Close();
        }

    }
}
