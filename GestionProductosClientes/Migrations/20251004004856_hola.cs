using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionProductosClientes.Migrations
{
    /// <inheritdoc />
    public partial class hola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "NombreM",
                table: "Producto",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 1,
                column: "NombreM",
                value: null);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 2,
                column: "NombreM",
                value: null);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 3,
                column: "NombreM",
                value: null);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 4,
                column: "NombreM",
                value: null);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "Id",
                keyValue: 5,
                column: "NombreM",
                value: null);
        }
    }
}
