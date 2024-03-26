using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneExAllievi.Migrations
{
    /// <inheritdoc />
    public partial class TestMattia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StipendioMensileRichiesto",
                table: "DatiExAllievi",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "StipendioMensileAttuale",
                table: "DatiExAllievi",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StipendioMensileRichiesto",
                table: "DatiExAllievi",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "StipendioMensileAttuale",
                table: "DatiExAllievi",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
