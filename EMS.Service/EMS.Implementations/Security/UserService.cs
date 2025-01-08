using System.Data;
using Dapper;
using EMS.Infrastructure.Domain.DTOs.User;
using EMS.Infrastructure.Domain.Entities.Security;
using EMS.Service.EMS.Abstractions.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMS.Service.EMS.Implementations.Security
{
    public class UserService :IUserService
    {
        private readonly UserManager<User> _service;
        private readonly IConfiguration _config;
        private readonly string _connection;

        public UserService(UserManager<User> user,IConfiguration config)
        {
            this._service = user;
            this._config = config;
            this._connection = config.GetConnectionString("ConStr")!;
        }

        public ValueTask<string> ConfirmpEmail(string username, string confirmationCode)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<List<User>> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var sql = "SELECT * FROM USER";
                var users = await connection.QueryAsync<User>(sql);
                return users.ToList();
            }
        }

        public async ValueTask<User> GetOne(string username)
        {
            if (username == null)
                throw new ArgumentNullException("Invalid Data");

            using(IDbConnection connection = new SqlConnection(_connection))
            {
                var sql = "SELECT * FORM USER WHERE USERNAME = @USERNAME";
                var user =  await connection.QueryFirstOrDefaultAsync<User>(sql,new { UserName = username});
                return user!;
            }
        }

        public ValueTask<string> Login(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        // this method must return confirmation code 
        public async ValueTask<string> Register(RegistrationDTO register)
        {
            if (register == null)
                return "User Data Invalid";

            var user = new User()
            {
                UserName = register.UserName,
                PasswordHash = register.Password,
                Address =  register.Address,
                Email = register.Email,
            };

            IdentityResult creationResult = await _service.CreateAsync(user,user.PasswordHash);
            if (!creationResult.Succeeded)
                return "Invalid Creation";

            




        }

        public ValueTask<string> RemoveUser(string username)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> UpdatePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
