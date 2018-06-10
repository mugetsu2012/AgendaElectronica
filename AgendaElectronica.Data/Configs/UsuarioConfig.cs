using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaElectronica.Data.Configs
{
    public class UsuarioConfig: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.NombreUsuario);
            builder.Property(t => t.NombreUsuario).HasMaxLength(100);
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Apellido).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.HasOne(t => t.Rol).WithMany().HasForeignKey(f => f.IdRol).IsRequired();

            builder.ToTable(nameof(Usuario));
        }
    }
}
