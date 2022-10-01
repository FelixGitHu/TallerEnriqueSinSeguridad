using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class ProveedorMejorado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Proveedors",
                newName: "Direccion");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Proveedors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Proveedors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Proveedors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreContacto",
                table: "Proveedors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpresa",
                table: "Proveedors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Proveedors");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Proveedors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Proveedors");

            migrationBuilder.DropColumn(
                name: "NombreContacto",
                table: "Proveedors");

            migrationBuilder.DropColumn(
                name: "NombreEmpresa",
                table: "Proveedors");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Proveedors",
                newName: "Nombre");
        }
    }
}
