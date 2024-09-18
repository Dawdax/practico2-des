using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    /// <inheritdoc />
    public partial class CambiamosnombredeselectorAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCandidates",
                table: "SelectorAgent",
                newName: "IdSelectorAgent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSelectorAgent",
                table: "SelectorAgent",
                newName: "IdCandidates");
        }
    }
}
