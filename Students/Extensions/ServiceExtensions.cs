﻿using Students.Contracts;
using Microsoft.EntityFrameworkCore;
using Students.Repository;
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


        /*public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                   services.AddDbContext<RepositoryContext>(opts =>
                       opts.UseMySQL(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("Students")));
                       */


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

    }
}
