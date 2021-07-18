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

namespace HRM.Api
{
    public static class Extension
    {
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

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IMemoryCaching, MemoryCaching>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICertificatedRepository, CertificatedRepository>();
            services.AddScoped<ICertificatedFactory, CertificatedFactory>();
            services.AddScoped<ICertificatedService, CertificatedService>();
        }
    }
}
