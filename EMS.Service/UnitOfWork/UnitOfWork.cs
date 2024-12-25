using EMS.Infrastructure.Presistence.Context;
using EMS.Service.EMS.Abstractions.Business;
using EMS.Service.EMS.Implementations.Business;

namespace EMS.Service.UnitOfWorks
{
    public class UnitOfWork : IUnotOfWork
    {
        private AppDbContext _app;
        public UnitOfWork(AppDbContext app)
        {
            this._app = app;
        }
        public IStudentService Students => new StudentService(_app);

        public IDepartmentService Departments => new DepartmentService(_app);

        public ICourseService Courses => new CourseService(_app);

        public IRoomService Rooms => new RoomService(_app);

        public IInstructorService Instructors => new InstructorService(_app);

        public void Dispose()
        {
            _app.Dispose();
        }

        public async ValueTask<int> SaveChanges()
        {
            return await _app.SaveChangesAsync();
        }

     
    }
}
