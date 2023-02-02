using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class FormaPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Monedas_MonedaId",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "MonedaId",
                table: "Ventas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FormaPago",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "dbda81e7-f80f-461c-b006-8a1767727595");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "0419a005-46fd-455e-ba1d-16fb57ed1848");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Monedas_MonedaId",
                table: "Ventas",
                column: "MonedaId",
                principalTable: "Monedas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Monedas_MonedaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "FormaPago",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "MonedaId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Mecanicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Monedas_MonedaId",
                table: "Ventas",
                column: "MonedaId",
                principalTable: "Monedas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
