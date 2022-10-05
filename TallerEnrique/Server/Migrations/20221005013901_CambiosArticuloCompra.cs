using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class CambiosArticuloCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Mecanicos_MecanicoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_MecanicoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "MecanicoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "PrecioUnitario",
                table: "Articulos",
                newName: "PrecioCompra");

            migrationBuilder.AddColumn<long>(
                name: "NFactura",
                table: "Compras",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVenta",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NFactura",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "PrecioVenta",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "PrecioCompra",
                table: "Articulos",
                newName: "PrecioUnitario");

            migrationBuilder.AddColumn<int>(
                name: "MecanicoId",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_MecanicoId",
                table: "Compras",
                column: "MecanicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Mecanicos_MecanicoId",
                table: "Compras",
                column: "MecanicoId",
                principalTable: "Mecanicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
