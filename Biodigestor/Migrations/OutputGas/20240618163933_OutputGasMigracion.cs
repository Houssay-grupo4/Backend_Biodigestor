using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.OutputGas
{
    /// <inheritdoc />
    public partial class OutputGasMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutputGases",
                columns: table => new
                {
                    IdOutput = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadGasSalida = table.Column<float>(type: "real", nullable: false),
                    IdBiodigestor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputGases", x => x.IdOutput);
                    table.ForeignKey(
                        name: "FK_OutputGases_Biodigestores_IdBiodigestor",
                        column: x => x.IdBiodigestor,
                        principalTable: "Biodigestores",
                        principalColumn: "IdBiodigestor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutputGases_IdBiodigestor",
                table: "OutputGases",
                column: "IdBiodigestor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutputGases");
        }
    }
}
