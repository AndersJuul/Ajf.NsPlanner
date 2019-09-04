using System;
using Ajf.NsPlanner.Domain.Entities;

namespace Ajf.NsPlanner.UI.Abstractions
{
    public interface IAvailableDateViewModel
    {
        DateTime Date { get; }
        IToggleAvailableDateCommand ToggleAvailableDateCommand { get; }
        Guid Id { get; }
        void ModelUpdate(AvailableDate availableDate);
    }
}