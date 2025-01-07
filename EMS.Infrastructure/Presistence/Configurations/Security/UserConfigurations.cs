using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Infrastructure.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Presistence.Configurations.Security
{
    public class UserConfigurations :
        IEntityTypeConfiguration<IdentityUser<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<string>> builder)
        {
            builder.ToTable("User").HasKey(x=>x.Id);
        }
    }
}
