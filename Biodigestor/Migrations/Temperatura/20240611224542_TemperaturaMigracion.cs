using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.Temperatura
{
    /// <inheritdoc />
    public partial class TemperaturaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Temperatura",
                columns: table => new
                {
                    IdTemperatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nivelTemperatura = table.Column<float>(type: "real", nullable: false),
                    fechaTemperatura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBiodigestor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.IdTemperatura);
                    table.ForeignKey(
                        name: "FK_Temperatura_Biodigestor_IdBiodigestor",
                        column: x => x.IdBiodigestor,
                        principalTable: "Biodigestor",
                        principalColumn: "IdBiodigestor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_IdBiodigestor",
                table: "Temperatura",
                column: "IdBiodigestor");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_IdTemperatura",
                table: "Temperatura",
                column: "IdTemperatura",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatura");

            migrationBuilder.DropTable(
                name: "Biodigestor");
        }
    }
}
