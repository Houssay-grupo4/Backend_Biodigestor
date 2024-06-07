using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.Biodigestor
{
    /// <inheritdoc />
    public partial class BiodigestorMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biodigestores",
                columns: table => new
                {
                    IdBiodigestor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreBiodigestor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloBiodigestor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolumenGas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biodigestores", x => x.IdBiodigestor);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biodigestores_IdBiodigestor",
                table: "Biodigestores",
                column: "IdBiodigestor",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biodigestores");
        }
    }
}
