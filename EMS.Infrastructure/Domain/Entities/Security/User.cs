using Microsoft.AspNetCore.Identity;

namespace EMS.Infrastructure.Domain.Entities.Security
{
    public class User : IdentityUser<string>
    {
        public string Address { set; get; }
    }

}
