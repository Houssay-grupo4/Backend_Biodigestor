using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.InputGas
{
    /// <inheritdoc />
    public partial class NewInputGasMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputGases",
                columns: table => new
                {
                    IdInputGas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadGasEntrada = table.Column<double>(type: "float", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBiodigestor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputGases", x => x.IdInputGas);
                    table.ForeignKey(
                        name: "FK_InputGases_Biodigestores_IdBiodigestor",
                        column: x => x.IdBiodigestor,
                        principalTable: "Biodigestores",
                        principalColumn: "IdBiodigestor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputGases_IdBiodigestor",
                table: "InputGases",
                column: "IdBiodigestor");

            migrationBuilder.CreateIndex(
                name: "IX_InputGases_IdInputGas",
                table: "InputGases",
                column: "IdInputGas",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputGases");
        }
    }
}
