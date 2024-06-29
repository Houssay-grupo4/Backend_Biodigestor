using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.Alertas
{
    /// <inheritdoc />
    public partial class AlertasMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraAlerta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelSeveridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloAlerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionAlerta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBiodigestor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alertas_Biodigestores_IdBiodigestor",
                        column: x => x.IdBiodigestor,
                        principalTable: "Biodigestores",
                        principalColumn: "IdBiodigestor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdAlerta",
                table: "Alertas",
                column: "IdAlerta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdBiodigestor",
                table: "Alertas",
                column: "IdBiodigestor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");
        }
    }
}
