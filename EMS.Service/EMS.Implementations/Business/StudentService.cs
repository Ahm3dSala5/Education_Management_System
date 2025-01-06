using System.Data;
using Dapper;
using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Presistence.Context;
using EMS.Infrastructure.Repositories;
using EMS.Service.EMS.Abstractions.Business;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Business
{
    public class StudentService : MainRepository<Student> , IStudentService
    {
        private AppDbContext _app;
        private readonly string _connection;
        public StudentService
            (AppDbContext app , IConfiguration config) : base(app,config)
        {
            this._app = app;
            this._connection = config.GetConnectionString("ConStr")!;
        }

        public async ValueTask<ICollection<Course>> GetStudentCourses(int ? id)
        {
            if (id <= 0 || id == null)
                throw new ArgumentNullException();

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = "SELECT * FROM STUDENTCOURSES WHERE STUDENTID = @Id";
                var courses = await connection.QueryAsync<Course>(Sql,new { Id = id});
                return courses.ToList();
            }
        }

        public async ValueTask<ICollection<Instructor>> GetStudentInstructor(int ?id)
        {
            if (id <= 0 || id == null)
                throw new ArgumentNullException();

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = "SELECT * FROM STUDENTINSTRUCTORS WHERE STUDENTID = @Id";
                var Instructors = await connection.QueryAsync<Instructor>(Sql, new { Id = id });
                return Instructors.ToList();
            }
        }
    }
}
