using EMS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Infrastructure
{
    public static class Modules
    {
        public static void AddInfrastructuresModules(this IServiceCollection service)
        {
            service.AddTransient(typeof(IMainRepository<>),typeof(MainRepository<>));
        }
    }
}
