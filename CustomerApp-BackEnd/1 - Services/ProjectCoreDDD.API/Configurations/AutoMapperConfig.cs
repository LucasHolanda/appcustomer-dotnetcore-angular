using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectCoreDDD.Application.AutoMapper;
using System;

namespace ProjectCoreDDD.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(CustomerProfile), typeof(UserSysProfile));
        }
    }
}