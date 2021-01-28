using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaERP.Infra.CrossCutting.Identity.Entities;

namespace SistemaERP.Infra.CrossCutting.Identity.Mappings
{
    public class ApplicationUserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Ignore(c => c.PhoneNumber);

            builder.ToTable("Usuarios");

        }
    }
}
