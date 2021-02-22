using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaERP.Infra.CrossCutting.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Infra.CrossCutting.Identity.Mappings
{
    public class UsuarioFuncaoMap : IEntityTypeConfiguration<UsuarioFuncao>
    {
        public void Configure(EntityTypeBuilder<UsuarioFuncao> builder)
        {
            builder.ToTable("UsuarioFuncao");
        }
    }
}
