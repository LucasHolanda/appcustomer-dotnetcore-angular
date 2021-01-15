using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCoreDDD.Infra.Data;
using System;

namespace ProjectCoreDDD.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SqlContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                p => p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null)
                                            //.MigrationsHistoryTable("nome_tabela_migrations")
                                            );

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), p => p.MigrationsAssembly("ProjectCoreDDD.Infra"));
            });
        }
    }
}