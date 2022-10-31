using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class MDVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Inventarios_InventarioId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "DVentaArticulos");

            migrationBuilder.DropTable(
                name: "DVentaServicios");

            migrationBuilder.RenameColumn(
                name: "InventarioId",
                table: "Ventas",
                newName: "ServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_InventarioId",
                table: "Ventas",
                newName: "IX_Ventas_ServicioId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManoObra",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Descuento",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IVA",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Kilometraje",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "DVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DVentas_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CategoriaId",
                table: "Ventas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DVentas_ArticuloId",
                table: "DVentas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_DVentas_VentaId",
                table: "DVentas",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Categorias_CategoriaId",
                table: "Ventas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Servicios_ServicioId",
                table: "Ventas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Categorias_CategoriaId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Servicios_ServicioId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "DVentas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_CategoriaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "ServicioId",
                table: "Ventas",
                newName: "InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ServicioId",
                table: "Ventas",
                newName: "IX_Ventas_InventarioId");

            migrationBuilder.AlterColumn<float>(
                name: "ManoObra",
                table: "Ventas",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Descuento",
                table: "Ventas",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Vehiculos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Vehiculos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kilometraje",
                table: "Vehiculos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehiculos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DVentaArticulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVentaArticulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DVentaArticulos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DVentaArticulos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DVentaServicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVentaServicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DVentaServicios_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DVentaServicios_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DVentaArticulos_ArticuloId",
                table: "DVentaArticulos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_DVentaArticulos_VentaId",
                table: "DVentaArticulos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DVentaServicios_ServicioId",
                table: "DVentaServicios",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_DVentaServicios_VentaId",
                table: "DVentaServicios",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Inventarios_InventarioId",
                table: "Ventas",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
