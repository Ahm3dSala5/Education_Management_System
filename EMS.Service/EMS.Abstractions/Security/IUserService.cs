using EMS.Infrastructure.Domain.DTOs.User;
using EMS.Infrastructure.Domain.Entities.Security;
using EMS.Infrastructure.Repositories;

namespace EMS.Service.EMS.Abstractions.Security
{
    public interface IUserService 
    {
        ValueTask<string> Register(RegistrationDTO register);
        ValueTask<string> Login(LoginDTO login);
        ValueTask<string> RemoveUser(string username);
        ValueTask<string> UpdatePassword(string username,string oldPassword,string newPassword);
        ValueTask<string> ConfirmpEmail(string username , string confirmationCode);
        ValueTask<User> GetOne(string username);
        ValueTask<List<User>> GetAll();
    }
}
