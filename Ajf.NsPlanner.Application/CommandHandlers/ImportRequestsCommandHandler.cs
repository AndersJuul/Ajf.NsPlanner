using System.Linq;
using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.Events;
using AutoMapper;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class ImportRequestsCommandHandler : ICommandHandler<ImportRequestsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ImportRequestsCommandHandler(IUnitOfWork unitOfWork, IRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public Result Handle(ImportRequestsCommand command)
        {
            var existingEventRequests = _repository.List<EventRequest>();

            // For each: Insert if it's new; update existing if it has been seen before.
            foreach (var requestDto in command.RequestDtos)
            {
                var existing = existingEventRequests.SingleOrDefault(x => x.TimeStamp == requestDto.TimeStamp);

                if (existing == null)
                {
                    var eventRequest = _mapper.Map<EventRequest>(requestDto);
                    _repository.Add(eventRequest);
                    eventRequest.Events.Add(new EventRequestCreatedEvent(eventRequest));

                    var assignment = Assignment.Create(eventRequest);
                    _repository.Add(assignment);
                    eventRequest.Events.Add(new AssignmentCreatedEvent(assignment));
                }
                else
                {
                    var update = _mapper.Map<EventRequest>(requestDto);
                    existing.UpdateFrom(update);
                    existing.Events.Add(new EventRequestUpdatedEvent(existing));
                    _repository.Update(existing);
                }
            }

            _unitOfWork.SaveChanges();

            return Result.Ok();
        }

    }
}