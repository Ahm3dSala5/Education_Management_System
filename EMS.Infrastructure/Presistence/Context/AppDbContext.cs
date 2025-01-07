using EMS.Infrastructure.Domain.Entities;
using EMS.Infrastructure.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
namespace EMS.Infrastructure.Presistence.Context
{
    public class AppDbContext :  IdentityDbContext<User,UserRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Instructor> Instructors { set; get; }
        public DbSet<Department> Departments { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
