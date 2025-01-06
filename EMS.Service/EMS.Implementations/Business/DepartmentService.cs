using System.Data;
using Dapper;
using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Business
{
    public class DepartmentService : MainRepository<Department>,IDepartmentService<Department>
    {
        private readonly AppDbContext _app;
        private readonly string _connection;
        public DepartmentService(AppDbContext app,IConfiguration config) : base(app, config)
        {
            this._app = app;
            this._connection = config.GetConnectionString("ConStr")!;
        }
        public async ValueTask<ICollection<Course>> GetDepartmentCourses(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            using(IDbConnection connection = new SqlConnection(_connection))
            {
                var sql = "SELECT * FROM COURSE WHERE DEPARTMENTID =@Id";
                var courses = await connection.QueryAsync<Course>(sql,new { Id = id});

                return courses.ToList();
            }
        }

        public async ValueTask<ICollection<Instructor>> GetDepartmentInstructor(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            using(IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = "SELECT * FROM INSTRUCTOR WHERE DEPARTMENTID = @Id";
                var Instractors = await connection.QueryAsync<Instructor>(Sql,new { Id = id});

                return Instractors.ToList();
            }
        }

        public async ValueTask<ICollection<Student>> GetDepartmentStudents(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = "SELECT * FROM STUDENT WHERE DEPARTMENTID = @Id";
                var students = await connection.QueryAsync<Student>(Sql,new {Id =id});

                return students.ToList();
            }
        }
    }
}
