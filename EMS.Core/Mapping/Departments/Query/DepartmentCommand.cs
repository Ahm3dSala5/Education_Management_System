using EMS.Core.Features.Departments.Query.Request;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Infrastructure.Domain.DTOs.Department;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddGetDepartmentByIdMapping()
        {
            CreateMap<DepartmentDTO, Department>()
                .ForMember(des => des.Manager, src => src.MapFrom(src => src.dept_Manager))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.dept_Name)).ReverseMap();
        }
    }
}
