using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Repositories;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface ICourseService :IMainRepository<Course>
    {
        ValueTask<ICollection<Student>> GetCourseStudents(int ?id);
        ValueTask<ICollection<Instructor>> GetCourseInstructor(int ? id);
    }
}
