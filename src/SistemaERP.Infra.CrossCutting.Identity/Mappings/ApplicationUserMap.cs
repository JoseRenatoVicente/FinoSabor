using SistemaERP.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaERP.Infra.CrossCutting.Identity.Mappings
{
    public class ApplicationUserMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


            builder.ToTable("Usuarios");

        }
    }
}
