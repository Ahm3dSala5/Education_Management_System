using System.Globalization;
using AutoMapper;
using EMS.Core.Features.Departments.Query.Request;
using EMS.Core.Response;
using EMS.Infrastructure.Domain.DTOs.Department;
using EMS.Infrastructure.Domain.Entities;
using EMS.Service.UnitOfWorks;
using MediatR;

namespace EMS.Core.Features.Departments.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<DepartmentDTO>> ,
        IRequestHandler<GetAllDepartmentQuery, Response<List<DepartmentDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork  _service;

        public DepartmentQueryHandler(IMapper mapper, IUnitOfWork  service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        public async Task<Response<DepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _service.Departments.GetOne(request.Id);
            var deptMapped = _mapper.Map<DepartmentDTO>(department);
            return deptMapped != null ? Success<DepartmentDTO>(deptMapped) : BadRequest<DepartmentDTO>(_message:"Department Not Found"); 
        }

        public async Task<Response<List<DepartmentDTO>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = await _service.Departments.GetAll();
            var deptMapped = _mapper.Map<List<DepartmentDTO>>(departments);
            return departments.Count() != 0 ? Success<List<DepartmentDTO>>(deptMapped) : BadRequest<List<DepartmentDTO>>(_message:"Department List Is Empty");
        }
    }
}
