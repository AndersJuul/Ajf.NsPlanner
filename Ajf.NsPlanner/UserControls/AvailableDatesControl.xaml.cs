using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.ViewModels;

namespace Ajf.NsPlanner.UI.UserControls
{
    /// <summary>
    ///     Interaction logic for AvailableDatesControl.xaml
    /// </summary>
    public partial class AvailableDatesControl : UserControl
    {
        public AvailableDatesControl()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is IEditDatesViewModel modelOld)
            {
                modelOld.PropertyChanged -= DataContext_PropertyChanged;
            }
            if (e.NewValue is IEditDatesViewModel model)
            {
                model.PropertyChanged += DataContext_PropertyChanged;

                UpdateControls(model);
            }
        }

        private void UpdateControls(IEditDatesViewModel model)
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.RowDefinitions.Add(new RowDefinition(){Height = new GridLength(30)});
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            AddControl(grid, new Label {Content = "Datoer"}, 0, 0);
            for (var index = 0; index < model.Months.Count; index++)
            {
                var monthViewModel = model.Months.OrderBy(c=>c.FirstInMonth).ToArray()[index];
                AddControl(grid, new MonthControl {DataContext = monthViewModel}, (index + 2) / 2, (index + 2) % 2);
            }

            Content = grid;
        }

        private void DataContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName==nameof(EditDatesViewModel.Months))
            {
                UpdateControls(DataContext as IEditDatesViewModel);
            }
        }

        private static void AddControl(Grid grid, UIElement uiElement, int row, int column)
        {
            grid.Children.Add(uiElement);
            Grid.SetRow(uiElement, row);
            Grid.SetColumn(uiElement, column);
        }
    }
}