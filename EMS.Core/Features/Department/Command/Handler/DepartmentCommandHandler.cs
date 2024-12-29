using EMS.Core.Features.Departments.Command.Request;
using MediatR;
using EMS.Service.UnitOfWorks;
using AutoMapper;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Features.Departments.Command.Handler
{
    public class DepartmentCommandHandler :
        IRequestHandler<CreateDepartmentCommand, string>
    {
        private readonly IUnotOfWork _service;
        private readonly IMapper _mapper;

        public DepartmentCommandHandler(IUnotOfWork service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<string> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentMapped = _mapper.Map<Department>(request);
           return  await _service.Departments.Create(departmentMapped);
        }
    }
}
