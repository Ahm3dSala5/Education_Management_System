using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Core.Features.Courses.Query.Model;
using EMS.Infrastructure.Domain.Entities;

namespace EMS.Core.Mapping.Courses
{
    public partial class CourseProfile
    {
        public void GetCoursesMapping()
        {
            CreateMap<CourseModel, Course>().
                ForMember(x => x.Id, x => x.MapFrom(x => x.cou_Id)).
                ForMember(x => x.DepartmentId, x => x.MapFrom(x => x.cou_Id)).
                ForMember(x => x.Code, x => x.MapFrom(x => x.cou_Code)).
                ForMember(x => x.Level, x => x.MapFrom(x => x.cou_Level)).
                ForMember(x => x.Hours, x => x.MapFrom(x => x.cou_Hours)).ReverseMap();
        }
    }
}
