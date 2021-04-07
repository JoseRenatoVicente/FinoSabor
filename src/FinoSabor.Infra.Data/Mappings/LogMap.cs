using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Infra.Data.Mappings
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {

        }
    }
}
