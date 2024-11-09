using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCitas.BD.Migrations
{
    /// <inheritdoc />
    public partial class BaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "TDocumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ContactosEmergencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Relacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosEmergencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactosEmergencias_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "ContactoEmergencia_UQ",
                table: "ContactosEmergencias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmergencias_PersonaId",
                table: "ContactosEmergencias",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "ContactosEmergencias");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "TDocumentos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
