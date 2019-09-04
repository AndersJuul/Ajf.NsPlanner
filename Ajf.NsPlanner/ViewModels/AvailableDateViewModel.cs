using System;
using System.Windows.Media;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class AvailableDateViewModel : ViewModel, IAvailableDateViewModel
    {
        private readonly AvailableDate _availableDate;

        public AvailableDateViewModel(AvailableDate availableDate,
            IToggleAvailableDateCommand toggleAvailableDateCommand)
        {
            _availableDate = availableDate;
            ToggleAvailableDateCommand = toggleAvailableDateCommand;
        }

        public DateTime Date => _availableDate.Date;
        public IToggleAvailableDateCommand ToggleAvailableDateCommand { get; }
        public Guid Id => _availableDate.Id;
        public Brush Brush => GetBrush( _availableDate.DateAvailability);
        public void ModelUpdate(AvailableDate availableDate)
        {
            _availableDate.UpdateFrom(availableDate);

            OnPropertyChanged(nameof(Brush));
        }

        private Brush GetBrush(DateAvailability dateAvailability)
        {
            switch (dateAvailability)
            {
                case DateAvailability.Available: return Brushes.Green;
                case DateAvailability.NotAvailable: return Brushes.Red;

                default: return Brushes.LightGray;
            }
        }
    }
}