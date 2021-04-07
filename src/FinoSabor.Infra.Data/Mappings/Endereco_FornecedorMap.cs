using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class Endereco_FornecedorMap : IEntityTypeConfiguration<Endereco_Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Endereco_Fornecedor> builder)
        {

        }
    }
}
