using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Business
{
    public class CourseService : MainRepository<Course>,ICourseService
    {
        private AppDbContext _app;
        public CourseService(AppDbContext app, IConfiguration config) : base(app, config)
        {
            this._app = app;
        }
        public ValueTask<ICollection<Instructor>> GetCourseInstructor(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Student>> GetCourseStudents(int id)
        {
            throw new NotImplementedException();
        }
    }
}
