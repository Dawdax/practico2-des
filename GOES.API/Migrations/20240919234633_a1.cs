using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOES.API.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "HojaDeVida",
                columns: table => new
                {
                    CandidatoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormacionAcademica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenciasPersonales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idiomas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaDeVida", x => x.CandidatoCodigo);
                    table.ForeignKey(
                        name: "FK_HojaDeVida_Candidato_CandidatoCodigo",
                        column: x => x.CandidatoCodigo,
                        principalTable: "Candidato",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitacora_HojaDeVida_CandidatoCodigo",
                        column: x => x.CandidatoCodigo,
                        principalTable: "HojaDeVida",
                        principalColumn: "CandidatoCodigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_CandidatoCodigo",
                table: "Bitacora",
                column: "CandidatoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "HojaDeVida");

            migrationBuilder.DropTable(
                name: "Candidato");
        }
    }
}
