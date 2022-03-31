using FinoSabor.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinoSabor.Infra.Data.Mappings.Identity
{
    public class UsuarioFuncaoMap : IEntityTypeConfiguration<UsuarioFuncao>
    {
        public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}
