using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaERP.Infra.CrossCutting.Identity.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Mappings;
using System;

namespace SistemaERP.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext
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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfiguration(new UsuarioFuncaoMap());
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
