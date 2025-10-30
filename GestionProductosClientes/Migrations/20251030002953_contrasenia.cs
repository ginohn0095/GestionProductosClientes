using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionProductosClientes.Migrations
{
    /// <inheritdoc />
    public partial class contrasenia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "Clientes",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contrasenia",
                value: "luis123");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Contrasenia",
                value: "maria123");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Contrasenia",
                value: "carlos123");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Contrasenia",
                value: "ana123");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Contrasenia",
                value: "jorge123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "Clientes");
        }
    }
}
