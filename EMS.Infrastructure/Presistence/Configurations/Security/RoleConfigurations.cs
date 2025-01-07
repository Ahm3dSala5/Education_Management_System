using EMS.Infrastructure.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations.Security
{
    public class RoleConfigurations : 
        IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // not add key becuse identityrole has alrady key configured
            builder.ToTable("Role").HasKey(x=> new { x.RoleId, x.UserId});
        }
    }
}
