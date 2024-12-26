using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student").HasKey(x=>x.Id);
            
            // department
            builder.HasOne(x=>x.Department)
                .WithMany(x=>x.Students)
                .HasForeignKey(x=>x.DepartmentId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            //course
            builder.HasMany(x => x.Courses)
                .WithMany(x => x.Students)
                .UsingEntity<StudentCourses>
                (
                  join => join.HasOne(x => x.Course)
                  .WithMany(x => x.StudentCourses)
                  .HasForeignKey(x => x.StudentId),
                 
                  join => join.HasOne(x => x.Student)
                  .WithMany(x=>x.StudentCourses)
                  .HasForeignKey(x=>x.CourseId)
                );

            //instructor
            builder.HasMany(x => x.Instructors)
                .WithMany(x => x.Students)
                .UsingEntity<StudentInstructors>
                (
                  join => join.HasOne(x => x.Instructor)
                  .WithMany(x => x.StudentInstructors)
                  .HasForeignKey(x => x.InstructorId),

                  join => join.HasOne(x => x.Student)
                  .WithMany(x => x.StudentInstructors)
                  .HasForeignKey(x => x.StudentId)
                );
        }
    }
}
