using EMS.Infrastructure.Domain.Entities;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface ICourseService
    {
        ValueTask<ICollection<Student>> GetCourseStudents(int id);
        ValueTask<ICollection<Instructor>> GetCourseInstructor(int id);
    }
}
