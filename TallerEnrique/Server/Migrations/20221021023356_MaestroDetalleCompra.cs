using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class MaestroDetalleCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Inventarios_InventarioId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_InventarioId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Compras");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DCompras",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<decimal>(
                name: "Descuento",
                table: "DCompras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "CostoTotal",
                table: "Compras",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<decimal>(
                name: "IVA",
                table: "Compras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Compras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "DCompras");

            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Compras");

            migrationBuilder.AlterColumn<float>(
                name: "PrecioUnitario",
                table: "DCompras",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "CostoTotal",
                table: "Compras",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_InventarioId",
                table: "Compras",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Inventarios_InventarioId",
                table: "Compras",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
