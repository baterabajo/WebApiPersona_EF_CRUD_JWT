using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigrationActivoFechaNacimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Personas");
        }
    }
}
