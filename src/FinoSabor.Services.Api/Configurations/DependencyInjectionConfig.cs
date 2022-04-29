using FinoSabor.Application.Categorias.Queries;
using FinoSabor.Application.Fornecedores.Queries;
using FinoSabor.Application.Notificacoes;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Produtos.Queries;
using FinoSabor.Application.Relatorio;
using FinoSabor.Application.Services;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Mediator;
using FinoSabor.Infra.CrossCutting.Identity.Extensions;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data;
using FinoSabor.Infra.Data.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinoSabor.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            //queries
            services.AddScoped<IProdutoQueries, ProdutoQueries>();
            services.AddScoped<ICategoriaQueries, CategoriaQueries>();
            services.AddScoped<IFornecedorQueries, FornecedorQueries>();

            //services
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<IPedidoService, PedidoService>();

            //Email            
            services.AddTransient<IEmailService, EmailService>();

            //repositories
            services.AddScoped<IEmailConfigRepository, EmailConfigRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoFornecedorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IItens_PedidoRepository, ItensPedidoRepository>();
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

            services.AddScoped<IMediatorHandler, MediatorHandler>();

        }
    }
}
