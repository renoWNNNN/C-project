using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inkTHINK.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDetalleImpuestosToCalculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetalleImpuestosJson",
                table: "Calculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetalleImpuestosJson",
                table: "Calculos");
        }
    }
}
