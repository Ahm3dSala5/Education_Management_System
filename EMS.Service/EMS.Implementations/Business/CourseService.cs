using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;

namespace EMS.Service.EMS.Implementations.Business
{
    public class CourseService : MainRepository<Course>,ICourseService
    {
        private AppDbContext _app;
        public CourseService(AppDbContext app) : base(app)
        {
            this._app = app;
        }
        public ValueTask<ICollection<Instructor>> GetCourseInstructor(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Student>> GetCourseStudents(int id)
        {
            throw new NotImplementedException();
        }
    }
}
