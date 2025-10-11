using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionProductosClientes.Migrations
{
    /// <inheritdoc />
    public partial class si : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "Producto",
                type: "INTEGER",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreM",
                table: "Producto",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreM = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Adidas" },
                    { 3, "Puma" },
                    { 4, "Reebok" },
                    { 5, "Under Armour" }
                });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[] { 3, null });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[] { 4, null });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IdMarca", "NombreM" },
                values: new object[] { 5, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "NombreM",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");
        }
    }
}
