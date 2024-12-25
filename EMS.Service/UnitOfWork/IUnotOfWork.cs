using EMS.Service.EMS.Abstractions.Business;

namespace EMS.Service.UnitOfWorks
{
    public interface IUnotOfWork :IDisposable
    {
        IStudentService Students { get; }
        IDepartmentService Departments { get; }
        ICourseService Courses { get; }
        IRoomService Rooms { get; }
        IInstructorService Instructors { get; }
        ValueTask<int> SaveChanges();
    }
}
