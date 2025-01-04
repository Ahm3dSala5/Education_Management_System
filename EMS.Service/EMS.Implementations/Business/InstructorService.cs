using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Business
{
    public class InstructorService : MainRepository<Instructor>, IInstructorService 
    {
        private AppDbContext _app;
        public InstructorService(AppDbContext app, IConfiguration config) : base(app, config)
        {
            this._app = app;
        }
        public ValueTask<ICollection<Course>> GetInstructorCourses(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Student>> GetInstructorStudents(int id)
        {
            throw new NotImplementedException();
        }
    }
}
