﻿// <auto-generated />
using System;
using AgendaElectronica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgendaElectronica.Data.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20180610023335_MigracionInicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgendaElectronica.Core.Models.Contacto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Direccion")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<int?>("IdMultimedia");

                    b.Property<string>("IdUsuario")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("TelefonoMovil")
                        .HasMaxLength(20);

                    b.Property<string>("TelefonoTrabajo")
                        .HasMaxLength(20);

                    b.HasKey("Codigo");

                    b.HasIndex("IdMultimedia");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("AgendaElectronica.Core.Models.Multimedia", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Archivo")
                        .IsRequired();

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NombreArchivo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Codigo");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("AgendaElectronica.Core.Models.Rol", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Codigo");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("AgendaElectronica.Core.Models.Usuario", b =>
                {
                    b.Property<string>("NombreUsuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("IdRol");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<byte[]>("Password")
                        .IsRequired();

                    b.HasKey("NombreUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AgendaElectronica.Core.Models.Contacto", b =>
                {
                    b.HasOne("AgendaElectronica.Core.Models.Multimedia", "Multimedia")
                        .WithMany()
                        .HasForeignKey("IdMultimedia");

                    b.HasOne("AgendaElectronica.Core.Models.Usuario", "Usuario")
                        .WithMany("Contactos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgendaElectronica.Core.Models.Usuario", b =>
                {
                    b.HasOne("AgendaElectronica.Core.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
