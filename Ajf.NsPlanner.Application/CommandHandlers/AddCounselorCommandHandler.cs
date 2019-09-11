using Ajf.NsPlanner.Application.Abstractions;
using Ajf.NsPlanner.Application.Commands;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using CSharpFunctionalExtensions;

namespace Ajf.NsPlanner.Application.CommandHandlers
{
    public class AddCounselorCommandHandler : ICommandHandler<AddCounselorCommand>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCounselorCommandHandler(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Result Handle(AddCounselorCommand command)
        {
            _repository.Add(Counselor.Create());
            
            _unitOfWork.SaveChanges();

            return Result.Ok();
        }
    }
}