using System;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class AddPeriodCommandHandler : ICommandHandler<AddPeriodCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPeriodCommandHandler(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(AddPeriodCommand command)
        {
            var period = Period.Create(DateRange.Create(DateTime.Today, DateTime.Today), "Efterår 2019");
            _repository.Add(period);

            period.Events.Add(new PeriodCreatedEvent(period));

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}