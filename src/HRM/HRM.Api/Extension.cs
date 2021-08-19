using DotNetCore.IoC;
using HRM.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Application.Common;
using HRM.Application.HR;
using HRM.Database.Common;
using HRM.Database.HR;
using Microsoft.Extensions.Caching.Memory;
using HRM.Infrastructure.Services;
using HRM.Application.System;
using HRM.Database.System;
using DotNetCore.Security;
using DotNetCore.AspNetCore;
using HRM.Model;
using Microsoft.Extensions.Configuration;

namespace HRM.Api
{
    public static class Extension
    {
        public const string SecretKey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWGfghf30iTOdtVWJGfghfGlOgJuQZdcF2Luqm/hccMw==";

        public static void AddContext(this IServiceCollection services)
        {
            var connectionString = services.GetConnectionString(nameof(Context));
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
        }

        public static void AddSecurity(this IServiceCollection services)
        {

        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRM.Api", Version = "v1" });
            });
        }

        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IMemoryCaching, MemoryCaching>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<ApiSettingModel>(config.GetSection("AppSettings"));

            services.AddHashService();
            services.AddJsonWebTokenService(SecretKey, TimeSpan.FromHours(12));
            services.AddAuthenticationJwtBearer();

            services.AddScoped<ICertificatedRepository, CertificatedRepository>();
            services.AddScoped<ICertificatedFactory, CertificatedFactory>();
            services.AddScoped<ICertificatedService, CertificatedService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictFactory, DistrictFactory>();
            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceFactory, ProvinceFactory>();
            services.AddScoped<IProvinceService, ProvinceService>();

            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IWardFactory, WardFactory>();
            services.AddScoped<IWardService, WardService>();

            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
