using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Security;
using DotNetCore.AspNetCore;
using HRM.Application.Common;
using HRM.Application.System;
using HRM.Database;
using HRM.Database.Common;
using HRM.Database.System;
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
        public const string SecretKey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWGfghf30iTOdtVWJGfghfGlOgJuQZdcF2Luqm/hccMw==";
        public static IServiceCollection UseDatabase(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString(nameof(Context));
            services.AddContext<Context>(options => options.UseSqlServer(connectionString));
            //services.AddUnitOfWork<Context>();
            return services;
        }

        public static IServiceCollection UseSecurity(this IServiceCollection services)
        {
            services.AddHashService();
            services.AddJsonWebTokenService(SecretKey, TimeSpan.FromHours(12));
            services.AddAuthenticationJwtBearer();
            return services;
        }

        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            services.AddScoped<Database.IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemoryCaching, MemoryCaching>();
            //services.AddScoped<IHashService, HashService>();
            //services.AddScoped<IJsonWebTokenService, JsonWebTokenService>();

            services.AddScoped<ToastMessageHelper, ToastMessageHelper>();

            services.AddScoped<ICertificatedRepository, CertificatedRepository>();
            services.AddScoped<ICertificatedFactory, CertificatedFactory>();
            services.AddScoped<ICertificatedService, CertificatedService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<ISystemUserRoleRepository, SystemUserRoleRepository>();
            services.AddScoped<ISystemFunctionRepository, SystemFunctionRepository>();

            return services;
        }

        public static IServiceCollection UseStaticFiles(this IServiceCollection services)
        {
            return services;
        }
    }
}
