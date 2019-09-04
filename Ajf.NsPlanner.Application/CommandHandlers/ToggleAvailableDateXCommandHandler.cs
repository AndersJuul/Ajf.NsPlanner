using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class ToggleAvailableDateXCommandHandler : ICommandHandler<ToggleAvailableDateXCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ToggleAvailableDateXCommandHandler(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(ToggleAvailableDateXCommand command)
        {
            var availableDate = _repository.GetById<AvailableDate>(command.AvailableDateId);

            availableDate.Toggle();

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}