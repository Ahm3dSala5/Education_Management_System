using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Repositories;

namespace EMS.Service.EMS.Abstractions.Business
{
    public interface IDepartmentService <T>: IMainRepository<T> where T :class
    {
        ValueTask<ICollection<Course>> GetDepartmentCourses(int id);
        ValueTask<ICollection<Instructor>> GetDepartmentInstructor(int id);
        ValueTask<ICollection<Student>> GetDepartmentStudents(int id);
    }
}
