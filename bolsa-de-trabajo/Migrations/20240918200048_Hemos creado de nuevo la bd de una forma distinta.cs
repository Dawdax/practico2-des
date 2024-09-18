using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    /// <inheritdoc />
    public partial class Hemoscreadodenuevolabddeunaformadistinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    IdCandidates = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.IdCandidates);
                });

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
                name: "CV",
                columns: table => new
                {
                    IdCv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalReferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lenguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.IdCv);
                    table.ForeignKey(
                        name: "FK_CV_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "IdCandidates",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesToJobs",
                columns: table => new
                {
                    IdCandidatesToJobs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesToJobs", x => x.IdCandidatesToJobs);
                    table.ForeignKey(
                        name: "FK_CandidatesToJobs_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "IdCandidates",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesToJobs_Jobs_JobId",
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
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    JobsIdJobs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectorAgent", x => x.IdCandidates);
                    table.ForeignKey(
                        name: "FK_SelectorAgent_Jobs_JobsIdJobs",
                        column: x => x.JobsIdJobs,
                        principalTable: "Jobs",
                        principalColumn: "IdJobs");
                });

            migrationBuilder.CreateTable(
                name: "BinnacleCV",
                columns: table => new
                {
                    IdBinnacleCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    Changes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalReferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lenguages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinnacleCV", x => x.IdBinnacleCV);
                    table.ForeignKey(
                        name: "FK_BinnacleCV_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "IdCv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectorAgentToJobs",
                columns: table => new
                {
                    IdSelectorAgentToJobs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SelectorAgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectorAgentToJobs", x => x.IdSelectorAgentToJobs);
                    table.ForeignKey(
                        name: "FK_SelectorAgentToJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "IdJobs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectorAgentToJobs_SelectorAgent_SelectorAgentId",
                        column: x => x.SelectorAgentId,
                        principalTable: "SelectorAgent",
                        principalColumn: "IdCandidates",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinnacleCV_CVId",
                table: "BinnacleCV",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesToJobs_CandidateId",
                table: "CandidatesToJobs",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesToJobs_JobId",
                table: "CandidatesToJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CandidateId",
                table: "CV",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAgent_JobsIdJobs",
                table: "SelectorAgent",
                column: "JobsIdJobs");

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAgentToJobs_JobId",
                table: "SelectorAgentToJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAgentToJobs_SelectorAgentId",
                table: "SelectorAgentToJobs",
                column: "SelectorAgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinnacleCV");

            migrationBuilder.DropTable(
                name: "CandidatesToJobs");

            migrationBuilder.DropTable(
                name: "SelectorAgentToJobs");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "SelectorAgent");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
