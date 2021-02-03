using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaERP.Infra.Data
{
    public partial class SistemaERPContext : DbContext
    {
        public readonly ILoggerFactory MyLoggerFactory;

        public readonly IAspNetUser AppUser;
        public SistemaERPContext(DbContextOptions<SistemaERPContext> options, IAspNetUser appUser) : base(options)
        {
            MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            AppUser = appUser;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<EmailModelo> EmailModelos { get; set; }
        public DbSet<EmailConfig> EmailConfigs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.LogChanges(AppUser);
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}