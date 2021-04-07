using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FinoSabor.Infra.Data;
using System;

namespace FinoSabor.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<FinoSaborContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),

                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });

            });
        }
    }
}
