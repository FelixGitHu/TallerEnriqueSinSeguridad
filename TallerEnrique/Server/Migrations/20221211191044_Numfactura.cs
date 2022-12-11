using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class Numfactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NFactura",
                table: "Ventas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NFactura",
                table: "Ventas");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "cb90868e-c1bd-4886-9527-89ea794254de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "857cd12d-5d93-47a5-b45b-cc0101d5e0e2");
        }
    }
}
