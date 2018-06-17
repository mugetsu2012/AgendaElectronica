using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaElectronica.Data.Configs
{
    public class RolConfig:IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(t => t.Codigo).ValueGeneratedOnAdd().IsRequired();
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(100);

            builder.ToTable(nameof(Rol));

            builder.HasData(
                new Rol { Codigo = 1, Nombre = "Usuario" },
                new Rol { Codigo = 2, Nombre = "Admin" }
            );
        }
    }
}
