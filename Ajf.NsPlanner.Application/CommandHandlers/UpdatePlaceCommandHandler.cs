using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class UpdatePlaceCommandHandler : ICommandHandler<UpdatePlaceCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePlaceCommandHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Result Handle(UpdatePlaceCommand command)
        {
            var place = _repository.GetById<Place>(command.Place.Id);
            place.UpdateFrom(command.Place);
            _repository.Update(place);

            place.Events.Add(new PlaceUpdatedEvent(place));

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}