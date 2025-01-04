using EMS.Infrastructure.Domain.Entities;
using EMS.Service.EMS.Abstractions.Business;

namespace EMS.Service.UnitOfWorks
{
    public interface IUnitOfWork :IDisposable
    {
        IStudentService Students { get; }
        IDepartmentService<Department> Departments { get; }
        ICourseService Courses { get; }
        IRoomService Rooms { get; }
        IInstructorService Instructors { get; }
        ValueTask<int> SaveChanges();
    }
}
