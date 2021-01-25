using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Entities.Email;
using SistemaERP.Domain.Entities.Identity;
using SistemaERP.Infra.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace SistemaERP.Infra.Data.Context
{
    public partial class SistemaERPContext : DbContext
    {
        public readonly ILoggerFactory MyLoggerFactory;
        public SistemaERPContext(DbContextOptions<SistemaERPContext> options) : base(options)
        {
            MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        //Identity
        //public DbSet<Usuario> Usuarios { get; set; }

        //SistemaERP

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos{ get; set; }
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Imagem> Imagens{ get; set; }


        //Email
        //public DbSet<TemplatesEmail> TemplatesEmails { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}