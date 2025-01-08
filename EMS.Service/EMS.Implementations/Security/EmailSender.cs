using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Infrastructure.Domain.Entities.Security;
using EMS.Service.EMS.Abstractions.Security;

namespace EMS.Service.EMS.Implementations.Security
{
    internal class EmailSender : IEmailSender
    {
        public void SendEmail(string message, User user)
        {

        }
    }
}
