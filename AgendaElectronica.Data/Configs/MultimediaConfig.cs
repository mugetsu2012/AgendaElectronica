using System;
using System.Collections.Generic;
using System.Text;
using AgendaElectronica.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaElectronica.Data.Configs
{
    public class MultimediaConfig:IEntityTypeConfiguration<Multimedia>
    {
        public void Configure(EntityTypeBuilder<Multimedia> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(t => t.Codigo).ValueGeneratedOnAdd();
            builder.Property(t => t.Archivo).IsRequired();
            builder.Property(t => t.Extension).IsRequired().HasMaxLength(25);
            builder.Property(t => t.MimeType).IsRequired().HasMaxLength(100);
            builder.Property(t => t.NombreArchivo).IsRequired().HasMaxLength(200);

            builder.ToTable(nameof(Multimedia));
        }
    }
}
