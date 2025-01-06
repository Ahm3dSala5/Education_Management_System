using EMS.Core.Features.Students.Query.Model;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetDepartmentStudentMapping()
        {
            CreateMap<StudentModel, Student>().
                ForMember(x => x.Id, x => x.MapFrom(x => x.std_id)).
                ForMember(x => x.DepartmentId, x => x.MapFrom(x => x.std_deptId)).
                ForMember(x => x.FirstName, x => x.MapFrom(x => x.std_FName)).
                ForMember(x => x.LastName, x => x.MapFrom(x => x.std_LName)).
                ForMember(x => x.Age, x => x.MapFrom(x => x.std_age)).
                ForMember(x => x.GPA, x => x.MapFrom(x => x.std_GPA)).
                ForMember(x => x.Address, x => x.MapFrom(x => x.std_address)).
                ForMember(x => x.BirthDate, x => x.MapFrom(x => x.std_birthDate)).ReverseMap();
        }
    }
}
