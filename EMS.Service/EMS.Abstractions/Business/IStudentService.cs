using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Repositories;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface IStudentService : IMainRepository<Student>
    {
        ValueTask<ICollection<Course>> GetStudentCourses(int ?id);
        ValueTask<ICollection<Instructor>> GetStudentInstructor(int? id);
    }
    
}
