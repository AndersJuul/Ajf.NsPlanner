using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.UserControls
{
    /// <summary>
    ///     Interaction logic for AvailableSingleDateControl.xaml
    /// </summary>
    public partial class AvailableSingleDateControl : UserControl
    {
        public AvailableSingleDateControl()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IAvailableDateViewModel model)
            {
                var content = new Button
                {
                    Content = model.Date.ToString("dd"),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Command = model.ToggleAvailableDateCommand,
                    Margin = new Thickness(2),
                    CommandParameter = model
                };
                content.SetBinding(BackgroundProperty, new Binding("Brush"));
                Content = content;
            }
        }
    }
}