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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HRM.Database.Assets;
using HRM.Application.Assets;

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

        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IMemoryCaching, MemoryCaching>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<ApiSettingModel>(config.GetSection("AppSettings"));

            var appSettingsSection = config.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<ApiSettingModel>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHashService();
            services.AddJsonWebTokenService(appSettings.SecretKey, TimeSpan.FromHours(0));
            //services.AddAuthenticationJwtBearer();

            services.AddingAssetServices(config);
            services.AddingCommonSettingServices(config);
            services.AddingHRContactsServices(config);
            services.AddingHRSettingServices(config);

        }

        private static void AddingAssetServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IAssetTypeFactory, AssetTypeFactory>();
            services.AddScoped<IAssetTypeService, AssetTypeService>();

            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetFactory, AssetFactory>();
            services.AddScoped<IAssetService, AssetService>();

            services.AddScoped<IAssetContractDetailRepository, AssetContractDetailRepository>();
            services.AddScoped<IAssetContractDetailFactory, AssetContractDetailFactory>();
            services.AddScoped<IAssetContractDetailService, AssetContractDetailService>();

            services.AddScoped<IAssetContractRepository, AssetContractRepository>();
            services.AddScoped<IAssetContractFactory, AssetContractFactory>();
            services.AddScoped<IAssetContractService, AssetContractService>();

            services.AddScoped<IAssetContractPaymentRepository, AssetContractPaymentRepository>();
            services.AddScoped<IAssetContractPaymentFactory, AssetContractPaymentFactory>();
            services.AddScoped<IAssetContractPaymentService, AssetContractPaymentService>();

        }

        private static void AddingCommonSettingServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICertificatedRepository, CertificatedRepository>();
            services.AddScoped<ICertificatedFactory, CertificatedFactory>();
            services.AddScoped<ICertificatedService, CertificatedService>();

            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolFactory, SchoolFactory>();
            services.AddScoped<ISchoolService, SchoolService>();

            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IMajorFactory, MajorFactory>();
            services.AddScoped<IMajorService, MajorService>();

            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IMaritalStatusFactory, MaritalStatusFactory>();
            services.AddScoped<IMaritalStatusService, MaritalStatusService>();

            services.AddScoped<IProfessionalQualificationRepository, ProfessionalQualificationRepository>();
            services.AddScoped<IProfessionalQualificationFactory, ProfessionalQualificationFactory>();
            services.AddScoped<IProfessionalQualificationService, ProfessionalQualificationService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictFactory, DistrictFactory>();
            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceFactory, ProvinceFactory>();
            services.AddScoped<IProvinceService, ProvinceService>();

            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IWardFactory, WardFactory>();
            services.AddScoped<IWardService, WardService>();

            services.AddScoped<ISystemRefreshTokenRepository, SystemRefreshTokenRepository>();
            services.AddScoped<IRefreshTokenFactory, RefreshTokenFactory>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        private static void AddingHRContactsServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IVendorFactory, VendorFactory>();
            services.AddScoped<IVendorService, VendorService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerContactRepository, CustomerContactRepository>();
            services.AddScoped<ICustomerContactFactory, CustomerContactFactory>();
            services.AddScoped<ICustomerContactService, CustomerContactService>();
        }

        private static void AddingHRSettingServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchFactory, BranchFactory>();
            services.AddScoped<IBranchService, BranchService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentFactory, DepartmentFactory>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
            services.AddScoped<IContractTypeFactory, ContractTypeFactory>();
            services.AddScoped<IContractTypeService, ContractTypeService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionFactory, PositionFactory>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IJobPositionRepository, JobPositionRepository>();
            services.AddScoped<IJobPositionFactory, JobPositionFactory>();
            services.AddScoped<IJobPositionService, JobPositionService>();

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveTypeFactory, LeaveTypeFactory>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();

            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<INationalityFactory, NationalityFactory>();
            services.AddScoped<INationalityService, NationalityService>();

            services.AddScoped<IRankingRepository, RankingRepository>();
            services.AddScoped<IRankingFactory, RankingFactory>();
            services.AddScoped<IRankingService, RankingService>();

            services.AddScoped<IEthnicityRepository, EthnicityRepository>();
            services.AddScoped<IEthnicityFactory, EthnicityFactory>();
            services.AddScoped<IEthnicityService, EthnicityService>();

            services.AddScoped<IModelOfStudyRepository, ModelOfStudyRepository>();
            services.AddScoped<IModelOfStudyFactory, ModelOfStudyFactory>();
            services.AddScoped<IModelOfStudyService, ModelOfStudyService>();

            services.AddScoped<IRelationshipTypeRepository, RelationshipTypeRepository>();
            services.AddScoped<IRelationshipTypeFactory, RelationshipTypeFactory>();
            services.AddScoped<IRelationshipTypeService, RelationshipTypeService>();

            services.AddScoped<IReligionRepository, ReligionRepository>();
            services.AddScoped<IReligionFactory, ReligionFactory>();
            services.AddScoped<IReligionService, ReligionService>();

            services.AddScoped<IEmployeeWorkingStatusRepository, EmployeeWorkingStatusRepository>();
            services.AddScoped<IEmployeeWorkingStatusFactory, EmployeeWorkingStatusFactory>();
            services.AddScoped<IEmployeeWorkingStatusService, EmployeeWorkingStatusService>();
        }
    }
}
