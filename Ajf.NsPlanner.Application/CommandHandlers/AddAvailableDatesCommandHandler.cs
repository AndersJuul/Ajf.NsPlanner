using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class AddAvailableDatesCommandHandler : ICommandHandler<AddAvailableDatesCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddAvailableDatesCommandHandler(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(AddAvailableDatesCommand command)
        {
            foreach (var availableDate in command.AvailableDatesToCreate)
            {
                _repository.Add(availableDate);
            }

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}