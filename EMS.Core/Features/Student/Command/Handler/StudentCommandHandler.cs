using AutoMapper;
using EMS.Core.Features.Students.Command.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.Entities;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Students
{
    public class StudentCommandHandler : ResultHandler,
        IRequestHandler<CreateStudentCommand, Result<string>>  ,
        IRequestHandler<UpdateStudentCommand, Result<string>>  ,
        IRequestHandler<DeleteStudentCommand, Result<string>> 
    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IUnitOfWork service , IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapped = _mapper.Map<Student>(request);
            var creationResult = await  _service.Students.Create(studentMapped);
            return creationResult == "Created" ? Create<string>(creationResult) : BadRequest<string>(creationResult);
        }

        public async Task<Result<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapped = _mapper.Map<Student>(request);
            var updationResult = await _service.Students.Update(studentMapped,request.Id);
            return updationResult == "Updated" ? Success<string>(updationResult) : BadRequest<string>(updationResult);
        }

        public async Task<Result<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var deletionResult = await _service.Students.Delete(request.Id);
            return deletionResult == "Deleted" ? Success<string>(deletionResult) : BadRequest<string>(deletionResult);
        }
    }
}