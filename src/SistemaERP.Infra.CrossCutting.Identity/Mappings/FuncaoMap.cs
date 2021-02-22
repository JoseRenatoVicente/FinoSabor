using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaERP.Infra.CrossCutting.Identity.Entities;

namespace SistemaERP.Infra.CrossCutting.Identity.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {

            builder.HasKey(u => u.Id);


            builder.ToTable("Funcao");
        }
    }
}
