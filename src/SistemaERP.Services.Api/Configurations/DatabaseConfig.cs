using SistemaERP.Infra.CrossCutting.Identity.Context;
using SistemaERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SistemaERP.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SistemaERPContext>(options =>
                    options.UseSqlServer(Settings.ConnectionString));



            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Settings.ConnectionString, b => b.MigrationsAssembly("SistemaERP.Infra.Data")));

        }
    }
}
