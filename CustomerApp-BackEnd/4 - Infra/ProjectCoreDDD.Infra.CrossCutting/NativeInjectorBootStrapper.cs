using Microsoft.Extensions.DependencyInjection;
using ProjectCoreDDD.Application;
using ProjectCoreDDD.Application.Interfaces;
using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using ProjectCoreDDD.Domain.Core.Interfaces.Services;
using ProjectCoreDDD.Domain.Services;
using ProjectCoreDDD.Infra.Data.Repositories;

namespace ProjectCoreDDD.Infra.CrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IUserSysAppService, UserSysAppService>();

            // Domain - Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserSysService, UserSysService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserSysRepository, UserSysRepository>();
        }
    }
}