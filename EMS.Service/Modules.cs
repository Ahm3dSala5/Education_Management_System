using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Service.EMS.Abstractions.Business;
using EMS.Service.EMS.Implementations.Business;
using EMS.Service.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Service
{
    public static class Modules
    {
        public static void AddBusinessModules(this IServiceCollection service)
        {
            service.AddTransient<IUnotOfWork,UnitOfWork>();
            service.AddTransient<IStudentService,StudentService>();
            service.AddTransient<IDepartmentService,DepartmentService>();
            service.AddTransient<ICourseService,CourseService>();
            service.AddTransient<IRoomService,RoomService>();
            service.AddTransient<IInstructorService,InstructorService>();
        }
    }
}
