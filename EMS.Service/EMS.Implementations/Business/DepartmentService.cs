using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.EntityFrameworkCore;

namespace EMS.Service.EMS.Implementations.Business
{
    public class DepartmentService : MainRepository<Department>,IDepartmentService<Department>
    {
        private AppDbContext _app;
        public DepartmentService(AppDbContext app) : base(app)
        {
            this._app = app;
        }
        public async ValueTask<ICollection<Course>> GetDepartmentCourses(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            var department = await _app.Departments.Include(x => x.courses).FirstOrDefaultAsync(x=>x.Id == id);
            if (department is null)
                throw new Exception("Department Not Found");


            var courses = department.courses.ToList();
            if (courses is null)
                throw new Exception("Department Not Has any courses");

            return courses;
        }

        public async ValueTask<ICollection<Instructor>> GetDepartmentInstructor(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            var department = await _app.Departments.Include(x => x.Instructors).FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
                throw new Exception("Department Not Found");

            var Instructors = department.Instructors.ToList();
            if (Instructors is null)
                throw new Exception("Department Not Has any Instructors");

            return Instructors;
        }

        public async ValueTask<ICollection<Student>> GetDepartmentStudents(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            var department = await _app.Departments.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
                throw new Exception("Department Not Found");

            var students = department.Students.ToList();
            if (students is null)
                throw new Exception("Department Not Has any Students");

            return students;
        }
    }
}
