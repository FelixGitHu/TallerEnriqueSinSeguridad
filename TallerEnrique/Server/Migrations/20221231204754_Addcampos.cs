using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class Addcampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Servicios");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ventas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Articulos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Articulos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "6a845d62-c0e6-4013-8b5f-87ec54d3b1f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "ebb82e43-b917-4901-a4b2-0590752b9b6e");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Articulos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Precio",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "48c84b19-3cd4-4200-b560-6542913257de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "10a79aad-a28f-477b-b68d-f4a17f3e35d5");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
