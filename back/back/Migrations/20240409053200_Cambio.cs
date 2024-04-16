using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class Cambio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cedulas_cedula",
                table: "Cedulas");

            migrationBuilder.DropColumn(
                name: "cedula",
                table: "Cedulas");

            migrationBuilder.DropColumn(
                name: "foto",
                table: "Cedulas");

            migrationBuilder.RenameColumn(
                name: "ubicacioncolegio",
                table: "Cedulas",
                newName: "UbicacionColegio");

            migrationBuilder.RenameColumn(
                name: "sexo",
                table: "Cedulas",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "sector",
                table: "Cedulas",
                newName: "Sector");

            migrationBuilder.RenameColumn(
                name: "municipio",
                table: "Cedulas",
                newName: "Municipio");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Cedulas",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "fechanacimiento",
                table: "Cedulas",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "estadocivil",
                table: "Cedulas",
                newName: "EstadoCivil");

            migrationBuilder.RenameColumn(
                name: "direccionresidencia",
                table: "Cedulas",
                newName: "DireccionResidencia");

            migrationBuilder.RenameColumn(
                name: "typeblood",
                table: "Cedulas",
                newName: "TipoSangre");

            migrationBuilder.RenameColumn(
                name: "ocupation",
                table: "Cedulas",
                newName: "Ocupacion");

            migrationBuilder.RenameColumn(
                name: "nacionality",
                table: "Cedulas",
                newName: "Nacionalidad");

            migrationBuilder.RenameColumn(
                name: "expdate",
                table: "Cedulas",
                newName: "FechaExpiracion");

            migrationBuilder.RenameColumn(
                name: "colegioelect",
                table: "Cedulas",
                newName: "ColegioElectoral");

            migrationBuilder.AddColumn<string>(
                name: "CedulaNumber",
                table: "Cedulas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CedulaNumber",
                table: "Cedulas");

            migrationBuilder.RenameColumn(
                name: "UbicacionColegio",
                table: "Cedulas",
                newName: "ubicacioncolegio");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Cedulas",
                newName: "sexo");

            migrationBuilder.RenameColumn(
                name: "Sector",
                table: "Cedulas",
                newName: "sector");

            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "Cedulas",
                newName: "municipio");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Cedulas",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Cedulas",
                newName: "fechanacimiento");

            migrationBuilder.RenameColumn(
                name: "EstadoCivil",
                table: "Cedulas",
                newName: "estadocivil");

            migrationBuilder.RenameColumn(
                name: "DireccionResidencia",
                table: "Cedulas",
                newName: "direccionresidencia");

            migrationBuilder.RenameColumn(
                name: "TipoSangre",
                table: "Cedulas",
                newName: "typeblood");

            migrationBuilder.RenameColumn(
                name: "Ocupacion",
                table: "Cedulas",
                newName: "ocupation");

            migrationBuilder.RenameColumn(
                name: "Nacionalidad",
                table: "Cedulas",
                newName: "nacionality");

            migrationBuilder.RenameColumn(
                name: "FechaExpiracion",
                table: "Cedulas",
                newName: "expdate");

            migrationBuilder.RenameColumn(
                name: "ColegioElectoral",
                table: "Cedulas",
                newName: "colegioelect");

            migrationBuilder.AddColumn<string>(
                name: "cedula",
                table: "Cedulas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "foto",
                table: "Cedulas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Cedulas_cedula",
                table: "Cedulas",
                column: "cedula",
                unique: true);
        }
    }
}
