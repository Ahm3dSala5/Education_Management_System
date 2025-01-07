using EMS.Infrastructure.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations.Security
{
    public class UserLoginsConfigurations : 
        IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("UserLogin").HasKey(x=> new { x.UserId,x.ProviderKey,x.LoginProvider});
        }
    }
}
