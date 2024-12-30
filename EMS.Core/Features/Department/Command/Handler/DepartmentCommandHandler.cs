using AutoMapper;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.Entities;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Departments.Command.Handler
{
    public class DepartmentCommandHandler : ResponseHandler ,
        IRequestHandler<CreateDepartmentCommand, Response<string>>
    {
        private readonly IUnotOfWork _service;
        private readonly IMapper _mapper;

        public DepartmentCommandHandler(IUnotOfWork service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentMapped = _mapper.Map<Department>(request);
            var result = await _service.Departments.Create(departmentMapped);
            
            return result == "Created" ? Create(result) : BadRequest<string>();
        }
    }
}
