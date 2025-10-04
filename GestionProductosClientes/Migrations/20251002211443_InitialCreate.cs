using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionProductosClientes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ApellidoMaterno", "ApellidoPaterno", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Lopez", "García", "Luis", "5512345678" },
                    { 2, "Sánchez", "Pérez", "María", "5523456789" },
                    { 3, "Diaz", "Ramírez", "Carlos", "5534567890" },
                    { 4, "Ortiz", "Martínez", "Ana", "5545678901" },
                    { 5, "Ruiz", "Hernández", "Jorge", "5556789012" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Existencia", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Sabor vainilla 1kg", 12, "Proteína Whey", 899.99m },
                    { 2, "Par de mancuernas recubiertas", 8, "Mancuerna 5kg", 599.50m },
                    { 3, "Set 3 niveles", 25, "Bandas Elásticas", 199.00m },
                    { 4, "Antideslizante 6mm", 30, "Colchoneta Yoga", 249.90m },
                    { 5, "Talla M", 20, "Guantes de gym", 149.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
