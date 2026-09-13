using Aptio.Application.Interfaces;
using Aptio.Infrastructure.DbContexts;
using Aptio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Aptio.Infrastructure
{
    public static class InfrastructureDIService
    {
        public static IServiceCollection AddInfrastructureDIService(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<AptioDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AptioDb")));
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}
