using Students.Contracts;
using Students.Repository;
using Students.Behaviors;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
namespace Students.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });




        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureValidationAssembly(this IServiceCollection services) =>
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        public static void ConfigureIdentityManager(this IServiceCollection services) =>
                services.AddTransient<IIdentityService, IdentityService>();
        public static void ConfigureCurrentUser(this IServiceCollection services) =>
               services.AddTransient<ICurrentUserService, CurrentUserService>();

        public static void ConfigureException(this IServiceCollection services) =>
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        public static void ConfigureAuthorization(this IServiceCollection services) => services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));

        public static void ConfigureValidationBehaviour(this IServiceCollection services) =>
       services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


        public static void ConfigurePerformanceBehaviour(this IServiceCollection services) => services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        /*    public static void ConfigureCacheBehavior(this IServiceCollection services) => services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
    */

    }
}
