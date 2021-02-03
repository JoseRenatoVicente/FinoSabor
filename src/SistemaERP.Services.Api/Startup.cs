using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaERP.Infra.Data;
using SistemaERP.Services.Api.Configurations;

namespace SistemaERP.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //Setting Identity
            services.AddIdentityConfig(Configuration);

            //EmailSettings
            //services.Configure<EmailConfig>(Configuration.GetSection("EmailSettings"));

            //Config Repositories
            services.ResolveDependencies();

            //Adding Logging
            services.AddLogging();

            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            //services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Adding AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Addinge Health Check
            //services.AddHealthChecks();

            //Mvc Config
            services.AddMvcConfiguration();

            //Optimization Compression
            //services.AddCompressionConfiguration();

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SistemaERPSeeder seedingService)
        {
            if (env.IsDevelopment())
            {
                //mostra a tela de erro no Asp .Net
                app.UseDeveloperExceptionPage();
                //Inicia o seedservice para popular o banco de dados
                seedingService.Seed();
            }
            else
            {
                //Impede ataques MITM
                app.UseHsts();
            }
            app.UseAuthentication();

            //Permitindo requisiçõs usando Header, Methods e Origen (Qualquer site)
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            //app.UseHealthChecks("/status");

            // Ativa a compressão
            app.UseResponseCompression();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

        }
    }
}