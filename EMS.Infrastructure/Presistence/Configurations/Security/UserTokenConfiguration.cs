using EMS.Infrastructure.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations.Security
{
    // when configure this table in data base user parent class not child
    public class UserTokenConfiguration : 
        IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("UserToken").HasKey(x=> new { x.UserId ,x.LoginProvider });
        }
    }
}
