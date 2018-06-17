using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

            builder.HasData(
                new Usuario
                {
                    Apellido = "Admin",
                    Nombre = "Admincito",
                    NombreUsuario = "admin",
                    IdRol = 2,
                    Password = "g2dgyiVaaGb+Ev6Sg3MzpMx8Sl86ZYn+dTjQV2D7LF0zKu481s0QYRX+zaS/wTL5"
                },
                new Usuario
                {
                    Apellido = "Anonimo",
                    Nombre = "Usuario",
                    NombreUsuario = "anon",
                    IdRol = 2,
                    Password = "g2dgyiVaaGb+Ev6Sg3MzpMx8Sl86ZYn+dTjQV2D7LF0zKu481s0QYRX+zaS/wTL5"
                }
            );
        }
    }
}
