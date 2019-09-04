using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Ajf.NsPlanner.UI.Abstractions;
using Ajf.NsPlanner.UI.Services;

namespace Ajf.NsPlanner.UI.UserControls
{
    /// <summary>
    ///     Interaction logic for StatListViewControl.xaml
    /// </summary>
    public partial class StatListViewControl
    {
        public StatListViewControl()
        {
            InitializeComponent();
        }

        private void UpdateColumns(ISimpleStatsViewModel m)
        {
            var gridView = ListView.View as GridView;
            gridView.Columns.Clear();

            foreach (DataColumn column in m.StatTable.DataTable.Columns)
            {
                var gridViewColumn = new GridViewColumn
                {
                    Header = m.Translate(column.ColumnName),
                    DisplayMemberBinding = new Binding(column.ColumnName)
                };
                gridViewColumn.SetValue(GridViewSort.PropertyNameProperty, column.ColumnName);
                gridView.Columns.Add(gridViewColumn);
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(
                new DependencyObject()))
                return;

            if (e.NewValue is ISimpleStatsViewModel model)
            {
                model.PropertyChanged += Model_PropertyChanged;
                UpdateColumns(model);
            }
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(
                new DependencyObject()))
                return;


            if (DataContext is ISimpleStatsViewModel m)
                if (e.PropertyName == "StatTable")
                    UpdateColumns(m);
        }
    }
}