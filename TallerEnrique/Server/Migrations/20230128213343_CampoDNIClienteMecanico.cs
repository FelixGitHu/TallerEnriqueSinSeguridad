using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class CampoDNIClienteMecanico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Articulos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "e9ce7f50-1b37-464e-9307-54766103288c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "dac00707-5d94-461e-8fd0-09cb4b3b2a3f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Articulos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "d0b5cb57-a631-49c5-a8e4-ca3baf45e0c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "8d1cdbcc-7df4-47e3-b9fb-1fef899765a7");
        }
    }
}
