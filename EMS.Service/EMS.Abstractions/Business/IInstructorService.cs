using EMS.Infrastructure.Domain.Entities;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface IInstructorService
    {
        ValueTask<ICollection<Student>> GetInstructorStudents(int id);
        ValueTask<ICollection<Course>> GetInstructorCourses(int id);
    }
}
