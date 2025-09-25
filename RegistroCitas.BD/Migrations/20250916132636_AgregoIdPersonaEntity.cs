using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCitas.BD.Migrations
{
    /// <inheritdoc />
    public partial class AgregoIdPersonaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactosEmergencias_Personas_PersonaId",
                table: "ContactosEmergencias");

            migrationBuilder.DropIndex(
                name: "ContactosEmergencia_UQ",
                table: "ContactosEmergencias");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "ContactosEmergencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactosEmergencias_Personas_PersonaId",
                table: "ContactosEmergencias",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactosEmergencias_Personas_PersonaId",
                table: "ContactosEmergencias");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "ContactosEmergencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "ContactosEmergencia_UQ",
                table: "ContactosEmergencias",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactosEmergencias_Personas_PersonaId",
                table: "ContactosEmergencias",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
