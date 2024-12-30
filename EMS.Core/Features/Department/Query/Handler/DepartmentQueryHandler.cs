using AutoMapper;
using EMS.Core.Features.Departments.Query.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnotOfWork _service;

        public DepartmentQueryHandler(IMapper mapper, IUnotOfWork service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<Response<DepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _service.Departments.GetOne(request.Id);
            var deptMapped = _mapper.Map<DepartmentDTO>(department);
            
            return Success(deptMapped);
        }
    }
}
