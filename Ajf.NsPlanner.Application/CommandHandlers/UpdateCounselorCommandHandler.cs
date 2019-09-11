using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class UpdateCounselorCommandHandler : ICommandHandler<UpdateCounselorCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCounselorCommandHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Result Handle(UpdateCounselorCommand command)
        {
            var counselor = _repository.GetById<Counselor>(command.Counselor.Id);
            counselor.UpdateFrom(command.Counselor);
            _repository.Update(counselor);

            counselor.Events.Add(new CounselorUpdatedEvent(counselor));

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}