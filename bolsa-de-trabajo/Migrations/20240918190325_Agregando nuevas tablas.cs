using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    /// <inheritdoc />
    public partial class Agregandonuevastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_BinnacleCV_CVId",
                table: "BinnacleCV",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_CandidateId",
                table: "CV",
                column: "CandidateId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinnacleCV");

            migrationBuilder.DropTable(
                name: "CV");
        }
    }
}
