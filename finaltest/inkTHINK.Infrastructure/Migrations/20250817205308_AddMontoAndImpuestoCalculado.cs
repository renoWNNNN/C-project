using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inkTHINK.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMontoAndImpuestoCalculado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ImpuestoCalculado",
                table: "Calculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Calculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpuestoCalculado",
                table: "Calculos");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Calculos");
        }
    }
}
