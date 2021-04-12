using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Mappings;
using FinoSabor.Infra.Data.Mappings.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data
{
    public partial class FinoSaborContext : IdentityDbContext
        <
            Usuario,
            Funcao,
            Guid,
            IdentityUserClaim<Guid>,
            UsuarioFuncao,
            IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>>
    {
        public readonly IAspNetUser _AppUser;

        public FinoSaborContext(DbContextOptions<FinoSaborContext> options, IAspNetUser AppUser) : base(options)
        {
            _AppUser = AppUser;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Categoria> categoria { get; set; }
        //public DbSet<EmailConfig> EmailConfigs { get; set; }
        //public DbSet<EmailModelo> EmailModelos { get; set; }
        public DbSet<Endereco_Fornecedor> endereco_fornecedor { get; set; }
        public DbSet<Fornecedor> fornecedor { get; set; }
        public DbSet<Imagem_Produto> imagem_produto { get; set; }
        public DbSet<Compra> compra { get; set; }
        public DbSet<Itens_Compra> itens_compra { get; set; }
        public DbSet<Log> log { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Itens_Pedido> itens_pedido { get; set; }
        public DbSet<Pessoa> pessoa { get; set; }
        public DbSet<Produto> produto { get; set; }

        //identity
        public DbSet<RefreshToken> refresh_token { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new Itens_PedidoMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new Itens_CompraMap());
            modelBuilder.ApplyConfiguration(new Imagem_ProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new Endereco_FornecedorMap());



            //identity
            modelBuilder.ApplyConfiguration(new UsuarioFuncaoMap());
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new RefreshTokenMap());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.LogChanges(_AppUser);
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}