using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaERP.Infra.CrossCutting.Identity.Entities;

namespace SistemaERP.Infra.CrossCutting.Identity.Mappings
{
    public class UsuarioFuncaoMap : IEntityTypeConfiguration<UsuarioFuncao>
    {
        public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.ToTable("UsuarioFuncao");
        }
    }
}
