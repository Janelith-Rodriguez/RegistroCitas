using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCitas.BD.Migrations
{
    /// <inheritdoc />
    public partial class NuevoInicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "ContactoEmergencia_UQ",
                table: "ContactosEmergencias",
                newName: "ContactosEmergencia_UQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "ContactosEmergencia_UQ",
                table: "ContactosEmergencias",
                newName: "ContactoEmergencia_UQ");
        }
    }
}
