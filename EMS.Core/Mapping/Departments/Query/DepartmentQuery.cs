using EMS.Core.Features.Departments.Query.Request;
using EMS.Core.Features.Departments.Command.Request;
using EMS.Infrastructure.Domain.DTOs.Department;
using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Domain.DTOs.Courses;
using EMS.Core.Features.Departments.Query.Model;
using EMS.Infrastructure.Domain.DTOs.Instractors;

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

        public void GetDepartmentCourseMapping()
        {
            CreateMap<CourseModel, Course>().
                ForMember(x => x.Id, x => x.MapFrom(x => x.cou_Id)).
                ForMember(x => x.DepartmentId, x => x.MapFrom(x => x.cou_Id)).
                ForMember(x => x.Code, x => x.MapFrom(x => x.cou_Code)).
                ForMember(x => x.Level, x => x.MapFrom(x => x.cou_Level)).
                ForMember(x => x.Hours, x => x.MapFrom(x => x.cou_Hours)).ReverseMap();
        }
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
        public void GetDepartmentInstractorsMapping()
        {
            CreateMap<InstractorModel, Instructor>().
                ForMember(x => x.Id, x => x.MapFrom(x => x.inst_Id)).
                ForMember(x => x.DepartmentId, x => x.MapFrom(x => x.inst_DepartmentId)).
                ForMember(x => x.Name, x => x.MapFrom(x => x.inst_Name)).
                ForMember(x => x.Salary, x => x.MapFrom(x => x.inst_Salary)).
                ForMember(x => x.Address, x => x.MapFrom(x => x.inst_Address)).
                ForMember(x => x.JobTitle, x => x.MapFrom(x => x.inst_JobTitle)).
                ForMember(x => x.HireDate, x => x.MapFrom(x => x.inst_HireDate)).ReverseMap();
        }
    }
}
