using System.ComponentModel;
using System.Windows;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Models;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.Views
{
    /// <summary>
    ///     Interaction logic for EditDatesWindow.xaml
    /// </summary>
    public partial class EditDatesWindow 
    {
        public EditDatesWindow()
        {
            InitializeComponent();
        }
        
        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(
                new DependencyObject()))
                return;

            WindowManager.Register(this);
        }
    }
}