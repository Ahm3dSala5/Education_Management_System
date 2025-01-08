using EMS.Infrastructure.Domain.Entities.Security;

namespace EMS.Service.EMS.Abstractions.Security
{
    public interface IEmailSender 
    {
        public void SendEmail(string message ,User user);
    }
}
