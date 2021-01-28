using SistemaERP.Infra.CrossCutting.Identity.Context;
using SistemaERP.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;

namespace SistemaERP.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SistemaERPContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SistemaERP.Infra.Data")));

        }
    }
}
