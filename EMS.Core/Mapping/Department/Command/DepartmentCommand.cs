using EMS.Core.Features.Departments.Command.Request;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddCreateDepartmentMapping()
        {
            CreateMap<Department, CreateDepartmentCommand>()
                .ForMember(des => des.Manager, src => src.MapFrom(src => src.Manager))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.Name)).ReverseMap();
        }

        public void AddUpdateDepartmentMapping()
        {
            CreateMap<Department, UpdateDepartmentCommand>()
                .ForMember(des => des.Id, src => src.MapFrom(src => src.Id))
                .ForMember(des => des.Manager, src => src.MapFrom(src => src.Manager))
                .ForMember(des => des.Name, src => src.MapFrom(src => src.Name)).ReverseMap();
        }
    }
}
