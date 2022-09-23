using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerEnrique.Server.Migrations
{
    public partial class TablaConfiguracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcio",
                table: "Servicios");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Servicios",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Garantias",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Articulos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Configuracions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Encabezado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreNegocio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionServicios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garantias_ServicioId",
                table: "Garantias",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garantias_Servicios_ServicioId",
                table: "Garantias",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garantias_Servicios_ServicioId",
                table: "Garantias");

            migrationBuilder.DropTable(
                name: "Configuracions");

            migrationBuilder.DropIndex(
                name: "IX_Garantias_ServicioId",
                table: "Garantias");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Garantias");

            migrationBuilder.AddColumn<string>(
                name: "Descripcio",
                table: "Servicios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Articulos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
