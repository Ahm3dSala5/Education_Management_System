using AutoMapper;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.Entities;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Departments.Command.Handler
{
    public class DepartmentCommandHandler : ResultHandler ,
        IRequestHandler<CreateDepartmentCommand, Result<string>> ,
        IRequestHandler<UpdateDepartmentCommand,Result<string>> ,
        IRequestHandler<DeleteDepartmentCommand,Result<string>>

    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public DepartmentCommandHandler(IUnitOfWork service  ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentMapped = _mapper.Map<Department>(request);
            var result = await _service.Departments.Create(departmentMapped);
            
            return result == "Created" ? Create(result) : BadRequest<string>();
        }

        public async Task<Result<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deptMapped = _mapper.Map<Department>(request);
            var updatingResult = await _service.Departments.Update(deptMapped,request.Id);

            return updatingResult == "Updated" ? Success<string>(updatingResult) :BadRequest<string>(updatingResult);
        }

        public async Task<Result<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deletingResult = await _service.Departments.Delete(request.Id);
            return deletingResult == "Deleted" ? Success<string>(deletingResult) : BadRequest<string>(deletingResult);
        }
    }
}
