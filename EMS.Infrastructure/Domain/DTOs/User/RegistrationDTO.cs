using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Domain.DTOs.User
{
    public class RegistrationDTO
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
}
