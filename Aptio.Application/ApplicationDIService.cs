using Aptio.Application.MediatR.Behaviors;
using Aptio.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aptio.Application
{
    public static  class ApplicationDIService
    {
        public static IServiceCollection AddApplicationDIService(this IServiceCollection services)
        {
            // FluentValidation
            services.AddValidatorsFromAssembly(
                typeof(ApplicationDIService).Assembly);

            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    typeof(ApplicationDIService).Assembly);

                cfg.AddOpenBehavior(
                    typeof(ValidationBehavior<,>));
            });

            services.AddAutoMapper(cfg =>
            {
            }, typeof(ApplicationDIService).Assembly);

            services.AddScoped<IUserService, UserService>();
            
            return services;
        }
       
    }
}
