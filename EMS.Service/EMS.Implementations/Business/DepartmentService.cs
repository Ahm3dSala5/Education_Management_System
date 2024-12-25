using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;

namespace EMS.Service.EMS.Implementations.Business
{
    public class DepartmentService : MainRepository<Department>,IDepartmentService
    {
        private AppDbContext _app;
        public DepartmentService(AppDbContext app) : base(app)
        {
            this._app = app;
        }
        public ValueTask<ICollection<Course>> GetDepartmentCourses(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Instructor>> GetDepartmentInstructor(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Student>> GetDepartmentStudents(int id)
        {
            throw new NotImplementedException();
        }
    }
}
