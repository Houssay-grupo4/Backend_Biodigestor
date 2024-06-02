using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biodigestor.Migrations.Provisiones
{
    /// <inheritdoc />
    public partial class ProvisionesMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provisiones",
                columns: table => new
                {
                    IdProvision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaProvision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadGas = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provisiones", x => x.IdProvision);
                    table.ForeignKey(
                        name: "FK_Provisiones_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provisiones_IdCliente",
                table: "Provisiones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Provisiones_IdProvision",
                table: "Provisiones",
                column: "IdProvision",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provisiones");
        }
    }
}
