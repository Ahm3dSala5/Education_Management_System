using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;

namespace EMS.Service.EMS.Implementations.Business
{
    public class StudentService : MainRepository<Student> , IStudentService
    {
        private AppDbContext _app;
        public StudentService(AppDbContext app) : base(app)
        {
            this._app = app;
        }

        public ValueTask<ICollection<Course>> GetStudentCourses(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Instructor>> GetStudentInstructor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
