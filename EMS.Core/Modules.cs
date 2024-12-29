using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace EMS.Core
{
    public static class Modules
    {
        public static void AddCoreModules(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
