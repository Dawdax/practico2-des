using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOES.API.Migrations
{
    /// <inheritdoc />
    public partial class CambiamosNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidatos",
                table: "Candidatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bitacoras",
                table: "Bitacoras");

            migrationBuilder.RenameTable(
                name: "Candidatos",
                newName: "Candidato");

            migrationBuilder.RenameTable(
                name: "Bitacoras",
                newName: "Bitacora");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidato",
                table: "Candidato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bitacora",
                table: "Bitacora",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidato",
                table: "Candidato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bitacora",
                table: "Bitacora");

            migrationBuilder.RenameTable(
                name: "Candidato",
                newName: "Candidatos");

            migrationBuilder.RenameTable(
                name: "Bitacora",
                newName: "Bitacoras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidatos",
                table: "Candidatos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bitacoras",
                table: "Bitacoras",
                column: "Id");
        }
    }
}
