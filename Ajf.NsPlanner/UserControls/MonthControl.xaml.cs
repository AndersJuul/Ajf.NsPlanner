using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.UserControls
{
    /// <summary>
    /// Interaction logic for MonthControl.xaml
    /// </summary>
    public partial class MonthControl : UserControl
    {
        public MonthControl()
        {
            InitializeComponent();
        }

        private string[] Weekday = new[] {"M", "T", "O", "T", "F", "L", "S"};

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IMonthViewModel model)
            {
                var grid = new Grid { };
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                var label = new Label {Content = model.Name};
                AddControl(grid, label, 0, 0);

                for (var i = 0; i < 7; i++)
                {
                    AddControl(grid,new Label {Content =Weekday[i], HorizontalAlignment = HorizontalAlignment.Center, FontWeight = FontWeights .Bold},1,i );
                }

                var day = (int)model.FirstInMonth.Date.DayOfWeek;
                var r = 2;
                var c = (day+6)%7;

                foreach (var availableDateViewModel in model.Dates.OrderBy(x=>x.Date))
                {
                    AddControl(grid, new AvailableSingleDateControl { DataContext = availableDateViewModel }, r, c);

                    c = (c + 1) % 7;
                    if (c == 0)
                        r++;
                }
                
                Content = new Border
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = grid,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Padding = new Thickness(4),
                    Margin = new Thickness(4)
                };

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
