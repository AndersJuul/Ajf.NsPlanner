using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.UI.Abstractions;

namespace Ajf.NsPlanner.UI.ViewModels
{
    public class PlaceViewModel : ViewModel, IPlaceViewModel
    {
        private readonly IDispatcher _dispatcher;

        public PlaceViewModel(Place place, IDispatcher dispatcher)
        {
            Model = place;
            _dispatcher = dispatcher;
        }

        public Place Model { get; }

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                CommitChanges();
                OnPropertyChanged();
            }
        }

        public void CommitChanges()
        {
            try
            {
                _dispatcher.Dispatch(new UpdatePlaceCommand(Model));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Guid Id => Model.Id;
    }
}