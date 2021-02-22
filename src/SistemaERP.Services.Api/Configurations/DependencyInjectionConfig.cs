using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SistemaERP.Application.Notificacoes;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Infra.CrossCutting.Identity.Context;
using SistemaERP.Infra.CrossCutting.Identity.Extensions;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data;
using SistemaERP.Infra.Data.Repository;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;

namespace SistemaERP.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();            

            //Email            
            services.AddTransient<IEmailService, EmailService>();

            //repositories
            services.AddScoped<ITemplatesEmailRepository, TemplatesEmailRepository>();
            services.AddScoped<IEmailConfigRepository, EmailConfigRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            //auth
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //seeder
            services.AddScoped<SistemaERPSeeder>();

            services.AddScoped<ApplicationDbContext>();

            //notification
            services.AddScoped<INotificador, Notificador>();

        }
    }
}
