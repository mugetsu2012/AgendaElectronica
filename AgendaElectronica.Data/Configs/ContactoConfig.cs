using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaElectronica.Data.Configs
{
    public class ContactoConfig:IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(t => t.Codigo).ValueGeneratedOnAdd();
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Apellido).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Direccion).HasMaxLength(500);
            builder.Property(t => t.TelefonoMovil).HasMaxLength(20);
            builder.Property(t => t.TelefonoTrabajo).HasMaxLength(20);
            builder.Property(t => t.Email).HasMaxLength(200);

            builder.HasOne(t => t.Usuario).WithMany(m => m.Contactos).HasForeignKey(f => f.IdUsuario).IsRequired();
            builder.HasOne(t => t.Multimedia).WithMany().HasForeignKey(f => f.IdMultimedia);

            builder.ToTable(nameof(Contacto));

        }
    }
}
