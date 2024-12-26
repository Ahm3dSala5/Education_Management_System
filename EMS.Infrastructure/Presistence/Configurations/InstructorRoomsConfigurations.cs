using EMS.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations
{
    public class InstructorRoomsConfigurations : IEntityTypeConfiguration<InstructorRooms>
    {
        public void Configure(EntityTypeBuilder<InstructorRooms> builder)
        {
            builder.ToTable("InstructorRooms").HasKey(X=> new {X.InstructorId ,X.RoomId});
        }
    }
}
