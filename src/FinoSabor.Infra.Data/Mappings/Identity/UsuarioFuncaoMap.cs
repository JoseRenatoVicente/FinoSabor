using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities.Identity;

namespace FinoSabor.Infra.Data.Mappings.Identity
{
    public class UsuarioFuncaoMap : IEntityTypeConfiguration<UsuarioFuncao>
    {
        public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.ToTable("usuario_funcao");
        }
    }
}
