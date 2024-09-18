using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    /// <inheritdoc />
    public partial class Hicimoslasotrastablasysusconexiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    IdJobs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.IdJobs);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    IdCandidates = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.IdCandidates);
                    table.ForeignKey(
                        name: "FK_Candidates_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "IdJobs",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectorAgent",
                columns: table => new
                {
                    IdCandidates = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    jobsIdJobs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectorAgent", x => x.IdCandidates);
                    table.ForeignKey(
                        name: "FK_SelectorAgent_Jobs_jobsIdJobs",
                        column: x => x.jobsIdJobs,
                        principalTable: "Jobs",
                        principalColumn: "IdJobs",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_JobId",
                table: "Candidates",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAgent_jobsIdJobs",
                table: "SelectorAgent",
                column: "jobsIdJobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "SelectorAgent");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFinalizacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.Id);
                });
        }
    }
}
