using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Mappings;
using FinoSabor.Infra.Data.Mappings.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Categoria> Categoria { get; set; }
        //public DbSet<EmailConfig> EmailConfigs { get; set; }
        //public DbSet<EmailModelo> EmailModelos { get; set; }
        public DbSet<EnderecoFornecedor> EnderecoFornecedore { get; set; }
        public DbSet<Fornecedor> Fornecedore { get; set; }
        public DbSet<ImagemProduto> ImagemProduto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<ItensCompra> ItensCompra { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Produto> Produto { get; set; }

        //identity
        public DbSet<RefreshToken> RefreshToken { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItensPedidoMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new ItensCompraMap());
            modelBuilder.ApplyConfiguration(new ImagemProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new EnderecoFornecedorMap());

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