using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    /// <inheritdoc />
    public partial class Hemoscreadodenuevolabddeunaformadistinta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectorAgent_Jobs_JobsIdJobs",
                table: "SelectorAgent");

            migrationBuilder.DropIndex(
                name: "IX_SelectorAgent_JobsIdJobs",
                table: "SelectorAgent");

            migrationBuilder.DropColumn(
                name: "JobsIdJobs",
                table: "SelectorAgent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobsIdJobs",
                table: "SelectorAgent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAgent_JobsIdJobs",
                table: "SelectorAgent",
                column: "JobsIdJobs");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectorAgent_Jobs_JobsIdJobs",
                table: "SelectorAgent",
                column: "JobsIdJobs",
                principalTable: "Jobs",
                principalColumn: "IdJobs");
        }
    }
}
