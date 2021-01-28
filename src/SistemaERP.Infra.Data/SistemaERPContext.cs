using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Email;
using SistemaERP.Infra.CrossCutting.Identity.Extensions;
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

        //Logging
        public DbSet<LogEntry> LogEntries { get; set; }

        //Identity
        //public DbSet<Usuario> Usuarios { get; set; }

        //SistemaERP

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }


        //Email
        //public DbSet<TemplatesEmail> TemplatesEmails { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }




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