using AutoMapper;

namespace EMS.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentCourseMapping();
            AddCreateDepartmentMapping();
            AddUpdateDepartmentMapping();
            AddGetDepartmentByIdMapping();
            GetDepartmentStudentMapping();
            GetDepartmentInstractorsMapping();
        }
    }
}
