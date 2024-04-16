using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cedulas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechanacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nacionality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeblood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadocivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ocupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    colegioelect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ubicacioncolegio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccionresidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cedulas", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cedulas_cedula",
                table: "Cedulas",
                column: "cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cedulas");
        }
    }
}
