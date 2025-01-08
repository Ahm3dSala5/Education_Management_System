using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor").HasKey(x => x.Id);

            //department
            builder.HasOne(x=>x.Department)
                .WithMany(x=>x.Instructors)
                .HasForeignKey(x=>x.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);

            //course
            builder.HasMany(x => x.Courses)
                .WithMany(x => x.Instructors)
                .UsingEntity<InstructorCourses>
                (
                  join => join.HasOne(x => x.Course)
                  .WithMany(x => x.InstructorCourses)
                  .HasForeignKey(x => x.CourseId),

                  join => join.HasOne(x => x.Instructor)
                  .WithMany(x => x.InstructorCourses)
                  .HasForeignKey(x => x.InstructorId)
                );

            //room
            builder.HasMany(x => x.Rooms)
                .WithMany(x => x.Instructors)
                .UsingEntity<InstructorRooms>
                (
                  join => join.HasOne(x => x.Room)
                  .WithMany(x => x.InstructorRooms)
                  .HasForeignKey(x => x.RoomId),

                  join => join.HasOne(x => x.Instructor)
                  .WithMany(x => x.InstructorRooms)
                  .HasForeignKey(x => x.InstructorId)
                );
        }
    }
}
