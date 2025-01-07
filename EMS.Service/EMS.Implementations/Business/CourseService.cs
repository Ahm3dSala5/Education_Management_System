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
    public class CourseService : MainRepository<Course>,ICourseService
    {
        private AppDbContext _app;
        private readonly string _connection;
        public CourseService(AppDbContext app, IConfiguration config) : base(app, config)
        {
            this._app = app;
            this._connection = config.GetConnectionString("ConStr")!;
        }
        public async ValueTask<ICollection<Instructor>> GetCourseInstructor(int ?id)
        {
            if (id <= 0 || id == null )
                throw new ArgumentNullException("Invalid Data");

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                // this retrive instructor id 
                var Sql = "SELECT * FROM INSTRUCTORCOURSES WHERE CourseId = @Id";
                var instructors = await connection.QueryAsync<Instructor>(Sql, new { Id = id });

                return instructors.ToList();
            }
        }

        public async ValueTask<ICollection<Student>> GetCourseStudents(int ? id)
        {
            if (id <= 0 || id == null)
                throw new ArgumentNullException("Invalid Data");

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = "SELECT * FROM STUDENTCOURSES WHERE COURSEID = @Id";
                var students = await connection.QueryAsync<Student>(Sql,new { Id =id});
                
                return students.ToList();
            }
        }
    }
}
