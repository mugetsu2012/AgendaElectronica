using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaElectronica.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "NombreUsuario", "Apellido", "IdRol", "Nombre", "Password" },
                values: new object[] { "anon", "Anonimo", 2, "Usuario", "g2dgyiVaaGb+Ev6Sg3MzpMx8Sl86ZYn+dTjQV2D7LF0zKu481s0QYRX+zaS/wTL5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "NombreUsuario",
                keyValue: "anon");
        }
    }
}
