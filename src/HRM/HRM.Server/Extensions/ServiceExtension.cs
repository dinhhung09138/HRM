using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using HRM.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Server.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection UseDatabase(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString(nameof(Context));
            services.AddContext<Context>(options => options.UseSqlServer(connectionString));
            //services.AddUnitOfWork<Context>();
            return services;
        }

        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            services.AddScoped<Database.IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection UseStaticFiles(this IServiceCollection services)
        {
            return services;
        }
    }
}
