using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Service.EMS.Abstractions.Business;
using EMS.Service.EMS.Implementations.Business;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork 
    {
        private AppDbContext _app;
        private readonly IConfiguration config;

        public UnitOfWork(AppDbContext app ,IConfiguration config)
        {
            this._app = app;
            this.config = config;
        }
        public IStudentService Students => new StudentService(_app,config);

        public IDepartmentService<Department> Departments => new DepartmentService(_app, config);

        public ICourseService Courses => new CourseService(_app, config);

        public IRoomService Rooms => new RoomService(_app, config);

        public IInstructorService Instructors => new InstructorService(_app, config);

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
