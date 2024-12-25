using EMS.Infrastructure.Domain.Entities;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface IDepartmentService
    {
        ValueTask<ICollection<Course>> GetDepartmentCourses(int id);
        ValueTask<ICollection<Instructor>> GetDepartmentInstructor(int id);
        ValueTask<ICollection<Student>> GetDepartmentStudents(int id);
    }
}
