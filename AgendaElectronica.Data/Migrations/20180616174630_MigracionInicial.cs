using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaElectronica.Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Archivo = table.Column<byte[]>(nullable: false),
                    NombreArchivo = table.Column<string>(maxLength: 200, nullable: false),
                    Extension = table.Column<string>(maxLength: 25, nullable: false),
                    MimeType = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    NombreUsuario = table.Column<string>(maxLength: 100, nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.NombreUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    TelefonoMovil = table.Column<string>(maxLength: 20, nullable: true),
                    TelefonoTrabajo = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    IdUsuario = table.Column<string>(nullable: false),
                    IdMultimedia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Contacto_Multimedia_IdMultimedia",
                        column: x => x.IdMultimedia,
                        principalTable: "Multimedia",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacto_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "NombreUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { 1, "Usuario" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { 2, "Admin" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "NombreUsuario", "Apellido", "IdRol", "Nombre", "Password" },
                values: new object[] { "admin", "Admin", 2, "Admincito", "g2dgyiVaaGb+Ev6Sg3MzpMx8Sl86ZYn+dTjQV2D7LF0zKu481s0QYRX+zaS/wTL5" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdMultimedia",
                table: "Contacto",
                column: "IdMultimedia");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdUsuario",
                table: "Contacto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
