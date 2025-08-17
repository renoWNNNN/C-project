using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inkTHINK.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContribuyenteProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreadoEn",
                table: "Contribuyentes");

            migrationBuilder.RenameColumn(
                name: "Regimen",
                table: "Contribuyentes",
                newName: "RncCedula");

            migrationBuilder.RenameColumn(
                name: "NombreComercial",
                table: "Contribuyentes",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Contribuyentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Contribuyentes");

            migrationBuilder.RenameColumn(
                name: "RncCedula",
                table: "Contribuyentes",
                newName: "Regimen");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Contribuyentes",
                newName: "NombreComercial");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreadoEn",
                table: "Contribuyentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
