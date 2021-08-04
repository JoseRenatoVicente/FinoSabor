using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FinoSabor.Application.Notificacoes;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Relatorio;
using FinoSabor.Application.Services;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Infra.CrossCutting.Identity.Extensions;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data;
using FinoSabor.Infra.Data.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;

namespace FinoSabor.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            //services
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPerfilService, PerfilService>();

            //Email            
            services.AddTransient<IEmailService, EmailService>();

            //repositories
            services.AddScoped<IEmailConfigRepository, EmailConfigRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IEnderecoRepository, Endereco_FornecedorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IItens_PedidoRepository, Itens_PedidoRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            //auth
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //seeder
            services.AddScoped<FinoSaborSeeder>();

            //notification
            services.AddScoped<INotificador, Notificador>();

        }
    }
}
