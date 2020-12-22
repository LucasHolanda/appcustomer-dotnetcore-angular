using Microsoft.Extensions.DependencyInjection;
using ProjectCoreDDD.Infra.CrossCutting;
using System;

namespace ProjectCoreDDD.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}