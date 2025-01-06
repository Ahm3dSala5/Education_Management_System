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
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            GetCoursesMapping();
        }
    }
}
