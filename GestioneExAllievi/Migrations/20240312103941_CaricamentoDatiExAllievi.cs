using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneExAllievi.Migrations
{
    /// <inheritdoc />
    public partial class CaricamentoDatiExAllievi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatiExAllievi",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMedia = table.Column<int>(type: "int", nullable: false),
                    UsernamesSocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitoloDiStudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializzazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequentaUniversita = table.Column<bool>(type: "bit", nullable: false),
                    CercaLavoro = table.Column<bool>(type: "bit", nullable: false),
                    EOccupato = table.Column<bool>(type: "bit", nullable: false),
                    StipendioMensileAttuale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StipendioMensileRichiesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurriculumFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatiExAllievi", x => x.CodiceFiscale);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatiExAllievi");
        }
    }
}
