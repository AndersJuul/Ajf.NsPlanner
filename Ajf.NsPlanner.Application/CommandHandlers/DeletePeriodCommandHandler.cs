using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class DeletePeriodCommandHandler : ICommandHandler<DeletePeriodCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePeriodCommandHandler(IUnitOfWork unitOfWork,IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(DeletePeriodCommand command)
        {
            var period = _repository.GetById<Period>(command.PeriodId);
            if (period == null)
                throw new ArgumentException("Period not found by id: " + command.PeriodId);

            _repository.Delete(period);

            period.Events.Add(new PeriodDeletedEvent(period));

            _unitOfWork.SaveChanges();
            return Result.Ok();
        }
    }
}