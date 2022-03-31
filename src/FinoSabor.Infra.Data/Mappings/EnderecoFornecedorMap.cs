using FinoSabor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinoSabor.Infra.Data.Mappings
{
    public class EnderecoFornecedorMap : IEntityTypeConfiguration<EnderecoFornecedor>
    {
        public void Configure(EntityTypeBuilder<EnderecoFornecedor> builder)
        {

        }
    }
}
