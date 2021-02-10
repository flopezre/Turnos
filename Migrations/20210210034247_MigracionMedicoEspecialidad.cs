using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionMedicoEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoEspecialidad",
                columns: table => new
                {
                    idMedico = table.Column<int>(nullable: false),
                    idEspecialidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidad", x => new { x.idMedico, x.idEspecialidad });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Especialidad_idEspecialidad",
                        column: x => x.idEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "idEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Medico_idMedico",
                        column: x => x.idMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidad_idEspecialidad",
                table: "MedicoEspecialidad",
                column: "idEspecialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoEspecialidad");
        }
    }
}
