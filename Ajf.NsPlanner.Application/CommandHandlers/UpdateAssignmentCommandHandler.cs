using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class UpdateAssignmentCommandHandler : ICommandHandler<UpdateAssignmentCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAssignmentCommandHandler(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(UpdateAssignmentCommand command)
        {
            var assignment = _repository.GetById<Assignment>(command.Assignment.Id);
            assignment.UpdateFrom(command.Assignment);
            _repository.Update(assignment);

            assignment.Events.Add(new AssignmentUpdatedEvent(assignment));

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}