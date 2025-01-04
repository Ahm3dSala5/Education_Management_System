using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Features.Students.Command.Request;
using EMS.Infrastructure.Domain.DTOs.Students;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void CreateStudentMapping()
        {
            CreateMap<Student, CreateStudentCommand>()
                .ForMember(des => des.Age, x => x.MapFrom(x => x.Age))
                .ForMember(des => des.FirstName, x => x.MapFrom(x => x.FirstName))
                .ForMember(des => des.LastName, x => x.MapFrom(x => x.LastName))
                .ForMember(des => des.GPA, x => x.MapFrom(x => x.GPA))
                .ForMember(des => des.Address, x => x.MapFrom(x => x.Address))
                .ForMember(des => des.BirthDate, x => x.MapFrom(x => x.BirthDate))
                .ForMember(des => des.DepartmentId, x => x.MapFrom(x => x.DepartmentId))
                .ForMember(des => des.Level, x => x.MapFrom(x => x.Level)).ReverseMap();
        }

        public void UpdateStudentMapping()
        {
            CreateMap<Student, UpdateStudentCommand>()
              .ForMember(des => des.Id, x => x.MapFrom(x => x.Id))
              .ForMember(des => des.Age, x => x.MapFrom(x => x.Age))
              .ForMember(des => des.FirstName, x => x.MapFrom(x => x.FirstName))
              .ForMember(des => des.LastName, x => x.MapFrom(x => x.LastName))
              .ForMember(des => des.GPA, x => x.MapFrom(x => x.GPA))
              .ForMember(des => des.Address, x => x.MapFrom(x => x.Address))
              .ForMember(des => des.BirthDate, x => x.MapFrom(x => x.BirthDate))
              .ForMember(des => des.DepartmentId, x => x.MapFrom(x => x.DepartmentId))
              .ForMember(des => des.Level, x => x.MapFrom(x => x.Level)).ReverseMap();
        }
    }
}
