using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FinoSabor.Infra.Data;
using FinoSabor.Services.Api.Configurations;

namespace FinoSabor.Services.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // ASP.NET Identity Settings & JWT
            services.AddIdentityConfig(Configuration);

            // .NET Native DI Abstraction
            services.ResolveDependencies();

            //Adding Logging
            services.AddLogging();

            // WebAPI Config
            services.AddControllers();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // AutoMapper Settings
            services.AddAutoMapper(typeof(Startup));

            // Addinge Health Check
            //services.AddHealthChecks();

            // DinkToPDF
            services.AddDinkToPDFConfiguration();

            //Mvc Config
            services.AddMvcConfiguration();
            services.AddCors();

            //Optimization Compression
            //services.AddCompressionConfiguration();

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FinoSaborSeeder seedingService)
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();


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

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
                await next();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

        }
    }
}