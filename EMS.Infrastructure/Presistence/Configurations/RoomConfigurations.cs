using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room").HasKey(x => x.Id);

            //department
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict); ;

            //instructor
            builder.HasMany(x => x.Instructors)
                .WithMany(x => x.Rooms)
                .UsingEntity<InstructorRooms>
                (
                  join => join.HasOne(x => x.Instructor)
                  .WithMany(x => x.InstructorRooms)
                  .HasForeignKey(x => x.InstructorId),

                  join => join.HasOne(x => x.Room)
                  .WithMany(x => x.InstructorRooms)
                  .HasForeignKey(x => x.RoomId)
                );
        }
    }
}
