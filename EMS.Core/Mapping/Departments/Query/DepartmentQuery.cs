using EMS.Core.Features.Departments.Query.Model;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddGetDepartmentByIdMapping()
        {
            CreateMap<DepartmentModel, Department>()
                .ForMember(des => des.Id, src => src.MapFrom(src => src.dept_Id))
                .ForMember(des => des.Manager, src => src.MapFrom(src => src.dept_Manager))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.dept_Name)).ReverseMap();
        }
    }
}
