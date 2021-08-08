using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using HRM.Application.Common;
using HRM.Database;
using HRM.Database.Common;
using HRM.Infrastructure.Services;
using HRM.Server.Helpers;
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
            services.AddScoped<IMemoryCaching, MemoryCaching>();

            services.AddScoped<ToastMessageHelper, ToastMessageHelper>();

            services.AddScoped<ICertificatedRepository, CertificatedRepository>();
            services.AddScoped<ICertificatedFactory, CertificatedFactory>();
            services.AddScoped<ICertificatedService, CertificatedService>();

            return services;
        }

        public static IServiceCollection UseStaticFiles(this IServiceCollection services)
        {
            return services;
        }
    }
}
