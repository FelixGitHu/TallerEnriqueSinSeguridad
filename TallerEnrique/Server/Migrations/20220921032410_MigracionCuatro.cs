using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class MigracionCuatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Garantias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Existencia = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventarios_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMoneda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    YearCar = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Kilometraje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostoTotal = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    MecanicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Mecanicos_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedors_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    ManoObra = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    MonedaId = table.Column<int>(type: "int", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    MecanicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Mecanicos_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Monedas_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Monedas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCompras_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DCompras_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cierre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cierre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cierre_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cierre_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cierre_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DVentaArticulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true),
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Compras_InventarioId",
                table: "Compras",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_MecanicoId",
                table: "Compras",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DCompras_ArticuloId",
                table: "DCompras",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_DCompras_CompraId",
                table: "DCompras",
                column: "CompraId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ArticuloId",
                table: "Inventarios",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CategoriaId",
                table: "Servicios",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_InventarioId",
                table: "Ventas",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_MecanicoId",
                table: "Ventas",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_MonedaId",
                table: "Ventas",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VehiculoId",
                table: "Ventas",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cierre");

            migrationBuilder.DropTable(
                name: "DCompras");

            migrationBuilder.DropTable(
                name: "DVentaArticulos");

            migrationBuilder.DropTable(
                name: "DVentaServicios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Proveedors");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Garantias");
        }
    }
}
