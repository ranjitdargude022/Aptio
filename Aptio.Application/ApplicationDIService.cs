using Aptio.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Aptio.Application
{
    public static  class ApplicationDIService
    {
        public static IServiceCollection AddApplicationDIService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
       
    }
}
