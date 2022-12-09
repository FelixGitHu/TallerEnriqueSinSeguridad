using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class quiterelacionCierre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cierre_Categorias_CategoriaId",
                table: "Cierre");

            migrationBuilder.DropForeignKey(
                name: "FK_Cierre_Inventarios_InventarioId",
                table: "Cierre");

            migrationBuilder.DropForeignKey(
                name: "FK_Cierre_Ventas_VentaId",
                table: "Cierre");

            migrationBuilder.DropIndex(
                name: "IX_Cierre_CategoriaId",
                table: "Cierre");

            migrationBuilder.DropIndex(
                name: "IX_Cierre_InventarioId",
                table: "Cierre");

            migrationBuilder.DropIndex(
                name: "IX_Cierre_VentaId",
                table: "Cierre");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Cierre");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Cierre");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "Cierre");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Cierre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Cierre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "Cierre",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28f70cf5-6654-48f9-a9d3-0e772cce4bd9",
                column: "ConcurrencyStamp",
                value: "48d5a115-0589-40f8-84f5-1ce9275a4c52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a821084-bb87-4287-9b4d-5f7101b75063",
                column: "ConcurrencyStamp",
                value: "44cf11a7-a626-4502-a48f-b55c64dd241a");

            migrationBuilder.CreateIndex(
                name: "IX_Cierre_CategoriaId",
                table: "Cierre",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cierre_InventarioId",
                table: "Cierre",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cierre_VentaId",
                table: "Cierre",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cierre_Categorias_CategoriaId",
                table: "Cierre",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cierre_Inventarios_InventarioId",
                table: "Cierre",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cierre_Ventas_VentaId",
                table: "Cierre",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
