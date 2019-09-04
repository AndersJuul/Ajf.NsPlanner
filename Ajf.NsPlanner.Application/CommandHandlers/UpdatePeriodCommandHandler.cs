using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class UpdatePeriodCommandHandler : ICommandHandler<UpdatePeriodCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePeriodCommandHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Result Handle(UpdatePeriodCommand command)
        {
            var period = _repository.GetById<Period>(command.Period.Id);
            period.UpdateFrom(command.Period);
            _repository.Update(period);

            period.Events.Add(new PeriodUpdatedEvent(period));

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}